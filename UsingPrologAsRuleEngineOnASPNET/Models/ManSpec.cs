using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingPrologAsRuleEngineOnASPNET.Models
{
    /// <summary>
    /// 求婚男性のスペックです。
    /// </summary>
    public class ManSpec
    {
        /// <summary>年収(万円単位)です。</summary>
        public int annual_income { get; set; }

        /// <summary>身長(cm単位)です。</summary>
        public int height { get; set; }

        /// <summary>偏差値です。</summary>
        public int class_curve { get; set; }

        /// <summary>親が資産家かどうかです。</summary>
        public bool wealthy_parent { get; set; }
    }
}