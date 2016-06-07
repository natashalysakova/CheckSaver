using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckSaver.Models.Repository;

namespace CheckSaver.Models.Plugin
{
    interface IPlugin
    {
        void Initialize();
        void Handle();
        CheckSaveDbRepository Repository { get; set; }
    }

    abstract class Plugin : IPlugin
    {
        public abstract void Initialize();
        public abstract void Handle();
        public CheckSaveDbRepository Repository { get; set; }

        protected Plugin(CheckSaveDbRepository repository)
        {
            Repository = repository;
        }
    }
}
