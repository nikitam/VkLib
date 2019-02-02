using System;

namespace VkLib.Objects
{
    public abstract class VkPrincipal : VkObject
    {
        public String Id { get; set; }

        public String ScreenName { get; internal set; }

        public String Photo50 { get; internal set; }

        public String Photo100 { get; internal set; }

        public String Photo200 { get; internal set; }

        public abstract String DisplayName { get; }

        public String ExternalDisplayName { get; set; }
    }
}