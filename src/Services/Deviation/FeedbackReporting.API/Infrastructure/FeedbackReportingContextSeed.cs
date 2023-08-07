
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure;

internal class FeedbackReportingContextSeed
{
    public async Task SeedAsync(FeedbackReportingContext context, IWebHostEnvironment env, IOptions<FeedbackReportingSettings> settings, ILogger<FeedbackReportingContextSeed> logger)
    {
        var policy = CreatePolicy(logger, nameof(FeedbackReportingContextSeed));

        await policy.ExecuteAsync(async () =>
        {
            var useCustomizationData = settings.Value.UseCustomizationData;
            var contentRootPath = env.ContentRootPath;
            //var picturePath = env.WebRootPath;

            if (!context.FeedbackReportReplyMethods.Any())
            {
                await context.FeedbackReportReplyMethods.AddRangeAsync(useCustomizationData
                    ? GetFeedbackReplyMethodsFromFile(contentRootPath, logger)
                    : GetPreconfiguredFeedbackReplyMethods());

                await context.SaveChangesAsync();
            }

            if (!context.FeedbackReports.Any())
            {
                await context.FeedbackReports.AddRangeAsync(useCustomizationData
                    ? GetFeedbackDataFromFile(context, contentRootPath, logger)
                    : GetPreconfiguredFeedbackData(context));

                await context.SaveChangesAsync();
            }

            //if (!context.CatalogItems.Any())
            //{
            //    await context.CatalogItems.AddRangeAsync(useCustomizationData
            //        ? GetCatalogItemsFromFile(contentRootPath, context, logger)
            //        : GetPreconfiguredItems());

            //    await context.SaveChangesAsync();

            //    GetCatalogItemPictures(contentRootPath, picturePath);
            //}
        });
    }

    private AsyncRetryPolicy CreatePolicy(ILogger<FeedbackReportingContextSeed> logger, string prefix, int retries = 3)
    {
        return Policy.Handle<SqlException>().
            WaitAndRetryAsync(
                retryCount: retries,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    logger.LogWarning(exception, "[{prefix}] Error seeding database (attempt {retry} of {retries})", prefix, retry, retries);
                }
            );
    }

    private IEnumerable<FeedbackReportReplyMethod> GetFeedbackReplyMethodsFromFile(string contentRootPath, ILogger<FeedbackReportingContextSeed> logger)
    {
        string csvFeedbackReplyMethods = Path.Combine(contentRootPath, "Setup", "FeedbackReplyMethods.csv");

        if (!File.Exists(csvFeedbackReplyMethods))
        {
            return GetPreconfiguredFeedbackReplyMethods();
        }

        string[] csvheaders;
        try
        {
            string[] requiredHeaders = { "id", "feedbackreplymethod" };
            csvheaders = GetHeaders(csvFeedbackReplyMethods, requiredHeaders);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error reading CSV headers");
            return GetPreconfiguredFeedbackReplyMethods();
        }

        return File.ReadAllLines(csvFeedbackReplyMethods)
                                    .Skip(1) // skip header row
                                    .SelectTry(CreateFeedbackReplyMethod)
                                    .OnCaughtException(ex => { logger.LogError(ex, "Error creating feedback reply method while seeding database"); return null; })
                                    .Where(x => x != null);
    }

    private IEnumerable<FeedbackReport> GetFeedbackDataFromFile(FeedbackReportingContext context, string contentRootPath, ILogger<FeedbackReportingContextSeed> logger)
    {
        string csvFeedbackData = Path.Combine(contentRootPath, "Setup", "FeedbackData.csv");
        //var feedbackMethods = GetPreconfiguredFeedbackReplyMethods();

        if (!File.Exists(csvFeedbackData))
        {
            return GetPreconfiguredFeedbackData(context);
        }

        string[] csvheaders;
        try
        {
            string[] requiredHeaders = { "id", "firstname", "middlename", "lastname", "created", "reportdescription" };
            csvheaders = GetHeaders(csvFeedbackData, requiredHeaders);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error reading CSV headers");
            return GetPreconfiguredFeedbackData(context);
        }

        return File.ReadAllLines(csvFeedbackData)
                                    .Skip(1) // skip header row
                                    .SelectTry(s => CreateFeedbackData(s, context))
                                    .OnCaughtException(ex => { logger.LogError(ex, "Error creating feedback report while seeding database"); return null; })
                                    .Where(x => x != null);
    }

    private FeedbackReportReplyMethod CreateFeedbackReplyMethod(string idAndfeedbackReplyMethod)
    {
        idAndfeedbackReplyMethod = idAndfeedbackReplyMethod.Trim('"').Trim();

        if (string.IsNullOrEmpty(idAndfeedbackReplyMethod))
        {
            throw new Exception("FeedbackReplyMethod Id and Name is empty");
        }

        var idAndfeedbackReplyMethodArray = idAndfeedbackReplyMethod.Split(";");

        var idString = idAndfeedbackReplyMethodArray[0];
        var name = idAndfeedbackReplyMethodArray[1];

        if (!int.TryParse(idString, out var id))
        {
            throw new Exception("FeedbackReplyMethod Id is not an integer value.");
        }

        if (name.IsNullOrEmpty())
        {
            throw new Exception("FeedbackReplyMethod Name is empty.");
        }

        return new FeedbackReportReplyMethod
        {
            // Id = id,
            Name = name,
        };
    }

    private FeedbackReport CreateFeedbackData(string idAndfeedbackReplyMethod, FeedbackReportingContext context)
    {
        var feedbackMethods = context.FeedbackReportReplyMethods;

        if (!feedbackMethods.Any())
        {
            throw new Exception("No feedback methods found.");
        }

        idAndfeedbackReplyMethod = idAndfeedbackReplyMethod.Trim('"').Trim();

        if (string.IsNullOrEmpty(idAndfeedbackReplyMethod))
        {
            throw new Exception("FeedbackReplyMethod Id and Name is empty");
        }

        var idAndfeedbackReplyMethodArray = idAndfeedbackReplyMethod.Split(";");

        // "id", "firstname","middlename", "lastname", "created", "reportdescription"
        var idString = idAndfeedbackReplyMethodArray[0];
        var firstName = idAndfeedbackReplyMethodArray[1];
        var middleName = idAndfeedbackReplyMethodArray[2];
        var lastName = idAndfeedbackReplyMethodArray[3];
        var created = idAndfeedbackReplyMethodArray[4];
        var reportDescription = idAndfeedbackReplyMethodArray[5];

        if (!Guid.TryParse(idString, out var id))
        {
            throw new Exception("FeedbackReport Id is not an integer value.");
        }

        if (firstName.IsNullOrEmpty())
        {
            throw new Exception("FeedbackReport FirstName is empty.");
        }

        if (lastName.IsNullOrEmpty())
        {
            throw new Exception("FeedbackReport LastName is empty.");
        }

        if (!DateTime.TryParse(created, out var createdDate))
        {
            throw new Exception("FeedbackReport Created could not be parsed.");
        }

        if (reportDescription.IsNullOrEmpty())
        {
            throw new Exception("FeedbackReport ReportDescription is empty.");
        }

        return new FeedbackReport
        {
            Id = id,
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            Created = createdDate,
            Description = reportDescription,
            ReplyMethods = new() { feedbackMethods.RandomElement() }
        };
    }

    private string[] GetHeaders(string csvfile, string[] requiredHeaders, string[] optionalHeaders = null)
    {
        string[] csvheaders = File.ReadLines(csvfile).First().ToLowerInvariant().Split(';');

        if (csvheaders.Count() < requiredHeaders.Count())
        {
            throw new Exception($"requiredHeader count '{requiredHeaders.Count()}' is bigger then csv header count '{csvheaders.Count()}' ");
        }

        if (optionalHeaders != null)
        {
            if (csvheaders.Count() > requiredHeaders.Count() + optionalHeaders.Count())
            {
                throw new Exception($"csv header count '{csvheaders.Count()}'  is larger then required '{requiredHeaders.Count()}' and optional '{optionalHeaders.Count()}' headers count");
            }
        }

        foreach (var requiredHeader in requiredHeaders)
        {
            if (!csvheaders.Contains(requiredHeader))
            {
                throw new Exception($"does not contain required header '{requiredHeader}'");
            }
        }

        return csvheaders;
    }

    private IEnumerable<FeedbackReportReplyMethod> GetPreconfiguredFeedbackReplyMethods()
    {
        return new List<FeedbackReportReplyMethod>()
        {
            new() { Name = "Ingen återkoppling"},
            new() { Name = "Telefon" },
            new() { Name = "E-post" },
            new() { Name = "Brev" },
        };
    }

    private IEnumerable<FeedbackReport> GetPreconfiguredFeedbackData(FeedbackReportingContext context)
    {
        var feedbackMethods = context.FeedbackReportReplyMethods;

        if (!feedbackMethods.Any())
        {
            throw new Exception("No feedback methods found.");
        }

        return new List<FeedbackReport>()
        {
            new() {
                Id = Guid.Parse("{9D4E5FFA-C906-486A-B417-EF6E55DE1A80}"),
                FirstName = "Nisse",
                LastName = "Nilsson",
                Created = DateTimeOffset.Now,
                Description = "Sample feedback report",
                ReplyMethods = new() { feedbackMethods.RandomElement() }  }
        };
    }
}
