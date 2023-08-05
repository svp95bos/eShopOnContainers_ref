﻿global using Microsoft.AspNetCore.Mvc;
global using MediatR;
global using FluentValidation;
global using Google.Protobuf.Collections;
global using Grpc.Core;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
global using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
global using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Extensions;
global using Microsoft.eShopOnContainers.BuildingBlocks.IntegrationEventLogEF;
global using Microsoft.eShopOnContainers.BuildingBlocks.IntegrationEventLogEF.Services;
global using Microsoft.Extensions.Options;
global using Polly;
global using Polly.Retry;
global using Services.Common;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Services;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.Infrastructure;
global using System.Data.Common;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.IntegrationEvents;
global using Microsoft.AspNetCore.Http;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Queries;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Models;
global using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Extensions;
global using System.Runtime.Serialization;
