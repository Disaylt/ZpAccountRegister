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

namespace ZennoPosterProjectAccountRegister
{
    /// <summary>
    /// Класс для запуска выполнения скрипта
    /// </summary>
    public class Program : IZennoExternalCode
    {
        public static Instance Instance { get; private set; }
        public static IZennoPosterProjectModel ZennoPosterProject { get; private set; }
        /// <summary>
        /// Метод для запуска выполнения скрипта
        /// </summary>
        /// <param name="instance">Объект инстанса выделеный для данного скрипта</param>
        /// <param name="project">Объект проекта выделеный для данного скрипта</param>
        /// <returns>Код выполнения скрипта</returns>		
        public int Execute(Instance instance, IZennoPosterProjectModel project)
        {
            Instance = instance;
            ZennoPosterProject = project;

            WbRegister wbRegister = new WbRegister();
            wbRegister.StartRegistration();

            int executionResult = 0;
            return executionResult;
        }
    }
}