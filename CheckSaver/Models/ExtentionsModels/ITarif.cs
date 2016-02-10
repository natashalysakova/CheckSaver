using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSaver.Models.ExtentionsModels
{
    public interface ITarif
    {
        decimal Calculate(double difference);
    }
}
