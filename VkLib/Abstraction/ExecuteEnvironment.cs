using System;
using System.Collections.Generic;
using System.Globalization;

namespace VkLib.Abstraction
{

    public abstract class ExecuteEnvironment
    {
        public CultureInfo Culture { get; }

        protected ExecuteEnvironment(CultureInfo culture)
        {
            this.Culture = culture;
            this.NeedResend = false;
            this.PrepareParametersExtension = null;
        }

        public Boolean NeedResend { get; set; }

        public Action<Dictionary<String, String>> PrepareParametersExtension { get; set; }

        public abstract String CheckCaptcha(String captchaAddress);
    }
}