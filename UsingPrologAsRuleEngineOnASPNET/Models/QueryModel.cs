using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingPrologAsRuleEngineOnASPNET.Models
{
    /// <summary>
    /// 結婚できるかどうかの問い合わせ引数です。
    /// </summary>
    public class QueryModel
    {
        /// <summary>結婚可能の条件を記述した Prolog コードです。</summary>
        public string rule { get; set; }

        /// <summary>求婚男性のスペックです。</summary>
        public ManSpec man_spec { get; set; }
    }
}