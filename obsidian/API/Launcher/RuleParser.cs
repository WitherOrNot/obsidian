using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace obsidian
{
    public class OSRule
    {
        public string name { get; set; }
        public string version { get; set; }
        public string arch { get; set; }

        public bool Validate()
        {
            string realArch = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            OperatingSystem os = Environment.OSVersion;
            string realOS = $"{os.Version.Major}.{os.Version.Minor}";

            return ((name == null) || (name == "windows")) && ((arch == null) || (arch == realArch)) && ((version == null) || (Regex.Match(realOS, version).Success));
        }
    }

    public class FeatureRule
    {
        public bool is_demo_user { get; set; }
        public bool has_custom_resolution { get; set; }

        public bool Validate()
        {
            return (!is_demo_user && !has_custom_resolution);
        }
    }

    public class Rule
    {
        public string action { get; set; }
        public OSRule os { get; set; }
        public FeatureRule features { get; set; }

        public bool Validate()
        {
            return (action == "allow") == ((os == null) || os.Validate()) && ((features == null) || features.Validate());
        }
    }

    public class RuleParser
    {
        public static List<object> ParseLibs(JArray array)
        {
            List<object> outList = new List<object>();

            foreach (JObject item in array)
            {
                if (item.ContainsKey("rules"))
                {
                    bool valid = true;

                    foreach (JObject ruleObj in item["rules"])
                    {
                        Rule rule = ruleObj.ToObject<Rule>();
                        valid &= rule.Validate();
                    }

                    if (valid)
                    {
                        outList.Add(item);
                    }
                }
                else
                    outList.Add(item);
            }

            return outList;
        }

        public static List<string> ParseArgs(List<object> list)
        {
            List<string> outList = new List<string>();

            foreach (dynamic item in list)
            {
                if (item is string)
                    outList.Add((string)item);
                else
                {
                    bool valid = true;

                    foreach (dynamic ruleObj in item.rules)
                    {
                        Rule rule = ruleObj.ToObject<Rule>();
                        valid &= rule.Validate();
                    }

                    if (valid)
                    {
                        outList.Add((string)item.value);
                    }
                }
            }

            return outList;
        }
    }
}
