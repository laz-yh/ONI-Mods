using Newtonsoft.Json;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Power_Generator
{
    public abstract class SingletonOptions<T> where T : class, new()
    {

        public static T Instance
        {
            get
            {
                bool flag = SingletonOptions<T>.instance == null;
                if (flag)
                {
                    T t;
                    bool flag2 = (t = POptions.ReadSettings<T>()) == null;
                    if (flag2)
                    {
                        t = Activator.CreateInstance<T>();
                    }
                    SingletonOptions<T>.instance = t;
                }
                return SingletonOptions<T>.instance;
            }
            protected set
            {
                bool flag = value != null;
                if (flag)
                {
                    SingletonOptions<T>.instance = value;
                }
            }
        }

                protected static T instance;
    }

    [JsonObject(MemberSerialization.OptIn)]
    [ModInfo("", null, false)]
    [ConfigFile("config.json", true, true)]
    [RestartRequired]
    internal class Options : SingletonOptions<Options>
    {


        [JsonProperty]
        [Option("发电机倍率", "Increase the multiple of the generator", null)]
        [Limit(0.1,100)]
        public float PowerRatio { get; set; }


        [JsonProperty]
        [Option("电线倍率", "WireRatio default is 100.", null)]
        [Limit(0.1, 1000)]
        public float WireRatio { get; set; }


        [JsonProperty]
        [Option("电池倍率", "BatteryRatio default is 10.", null)]
        [Limit(0.1, 100)]
        public float BatteryRatio { get; set; }

        public Options()
        {
            this.PowerRatio = 10f;
            this.WireRatio = 100f;
            this.BatteryRatio = 10f;
        }






    }
}
