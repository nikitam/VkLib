using System;
using System.Globalization;
using VkLib.Abstraction;

namespace VkLib.Realization
{
    public class SimpleExecuteEnvironment: ExecuteEnvironment
    {
        public SimpleExecuteEnvironment(CultureInfo culture) : base(culture)
        {
        }

        public override String CheckCaptcha(String captchaAddress)
        {
            throw new NotImplementedException();
        }
    }
}