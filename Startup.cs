using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ATCUTKDBAPI.Interface;
using ATCUTKDBAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATCUTKDBAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
   
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("AllowedOrigin").Get<string[]>())
                        .AllowAnyHeader()
                        .WithExposedHeaders("authtoken")
                        .AllowAnyMethod();
                });
            });
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IItemMasterRepository, ItemMasterRepository>();
            services.AddScoped<ILedgerMasterRepository, LedgerMasterRepository>();
            services.AddScoped<IRoleDetRepository, RoleDetRepository>();
            services.AddScoped<IUserDetRepository, UserDetRepository>();
            services.AddScoped<IWorkTableDetRepository, WorkTableDetRepository>();
            services.AddScoped<IGRNProcessRepository, GRNProcessRepository>();
            services.AddScoped<IBinProcessRepository, BinProcessRepository>();
            services.AddScoped<IPickingProcessRepository, PickingProcessRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IOrderProcessRepository, OrderProcessRepository>();
            services.AddScoped<ILevelMasterRepository, LevelMasterRepository>();
            services.AddScoped<IDCProcessRepository, DCProcessRepository>();
            services.AddScoped<IWorkOrderProcessRepository, WorkOrderProcessRepository>();
            services.AddScoped<IReservedRepository, ReservedRepository>();
            services.AddScoped<IBundleProcessRepository, BundleProcessRepository>();
            services.AddScoped<IStockConversionRepository, StockConversionRepository>();
            services.AddScoped<IItemReorderRepository, ItemReorderRepository>();
            services.AddScoped<ICustomerMasterRepository, CustomerMasterRepository>();
            services.AddScoped<ITeamMasterRepository, TeamMasterRepository>();
            services.AddScoped<ITransportMasterRepository, TransportMasterRepository>();
            services.AddScoped<IEmployeeMasterRepository, EmployeeMasterRepository>();
            services.AddScoped<IDepartmentMasterRepository, DepartmentMasterRepository>();
            services.AddScoped<ISectionMasterRepository, SectionMasterRepository>();
            services.AddScoped<IItemLabelTypeMasterRepository, ItemLabelTypeMasterRepository>();
            services.AddScoped<ILabelTypeMasterRepository, LabelTypeMasterRepository>();
            services.AddScoped<IEmployeeProcessAssignRepository, EmployeeProcessAssignRepository>();
            services.AddScoped<IProcessMasterRepository, ProcessMasterRepository>();
            services.AddScoped<IStockTransferRepository, StockTransferRepository>();
            services.AddScoped<IStockAuditRepository, StockAuditRepository>();
            services.AddScoped<IBinMasterRepository, BinMasterRepository>();
            services.AddScoped<IPerpetualInventoryRepository, PerpetualInventoryRepository>();
            services.AddScoped<IDashRepository, DashRepository>();
            services.AddScoped<IShiftMasterRepository, ShiftMasterRepository>();
            services.AddScoped<IItemPackingRatioRepository, ItemPackingRatioRepository>();
            services.AddScoped<ILabelTypePrinterMasterRepository, LabelTypePrinterMasterRepository>();
            services.AddScoped<IPurchaseReturnRepository, PurchaseReturnRepository>();
            services.AddScoped<ISalesReturnRepository, SalesReturnRepository>();
            services.AddScoped<ISampleCategoryMasterRepository, SampleCategoryMasterRepository>();
            services.AddScoped<ISampleReturnRepository, SampleReturnRepository>();
            services.AddScoped<IOutwardTypeMasterRepository, OutwardTypeMasterRepository>();
            services.AddScoped<ITrollyFreezeRepository, TrollyFreezeRepository>();
            services.AddScoped<ITrolleyMasterRepository, TrolleyMasterRepository>();
            services.AddScoped<IControlPanelRepository, ControlPanelRepository>();
            services.AddScoped<IBoxMasterRepository, BoxMasterRepository>();
            services.AddScoped<IScanToShipRepository, ScanToShipRepository>();
            services.AddScoped<INewDespatchRepository, NewDespatchRepository>();
services.AddScoped<ITransportBoxMappingRepository, TransportBoxMappingRepository>();

            services.AddScoped<IGatePass_API_PushRepository, GatePass_API_PushRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ATCUTKDBAPI", Version = "v1" });
                c.OperationFilter<MyHeaderFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATCUTKDBAPI v1"));

            }
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
