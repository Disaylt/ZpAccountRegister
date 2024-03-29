﻿using System;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.Proxy;
using ZennoPosterProjectAccountRegister.WB;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.Models.Objects;
using ZennoPosterProjectAccountRegister.AccountStore;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using ZennoPosterProjectAccountRegister.RegisterService;
using ZennoPosterProjectAccountRegister.Logger;

namespace ZennoPosterProjectAccountRegister
{
    /// <summary>
    /// Класс для запуска выполнения скрипта
    /// </summary>
    public class Program : IZennoExternalCode
    {
        /// <summary>
        /// Метод для запуска выполнения скрипта
        /// </summary>
        /// <param name="instance">Объект инстанса выделеный для данного скрипта</param>
        /// <param name="project">Объект проекта выделеный для данного скрипта</param>
        /// <returns>Код выполнения скрипта</returns>
        public int Execute(Instance instance, IZennoPosterProjectModel project)
        {
            int executionResult = default;
            Configuration configuration = Configuration.Instance;

            configuration.Load(project);
            var services = new RussianMarketplaceServicesBuilder(instance, project);
            var options = OptionsCollector.Instance;
            var registrationServices = new RegistrationServiceCollector(services, options);
            var registerController = registrationServices.GetRegistrationController(configuration.Settings.Marketplace);
            registerController.StartRegistration();

            return executionResult;
        }
    }
}