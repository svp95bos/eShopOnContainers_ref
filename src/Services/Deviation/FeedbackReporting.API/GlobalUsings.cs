global using System.ComponentModel.DataAnnotations.Schema;
global using System.Data;
global using System.Data.Common;
global using System.Data.SqlClient;
global using System.Runtime.Serialization;

global using MediatR;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
global using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
global using Microsoft.eShopOnContainers.BuildingBlocks.IntegrationEventLogEF;
global using Microsoft.eShopOnContainers.BuildingBlocks.IntegrationEventLogEF.Services;
global using Microsoft.eShopOnContainers.BuildingBlocks.IntegrationEventLogEF.Utilities;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.EntityConfigurations;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Extensions;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Grpc;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model;
global using Microsoft.Extensions.Options;

global using Polly;
global using Polly.Retry;

global using Services.Common;
