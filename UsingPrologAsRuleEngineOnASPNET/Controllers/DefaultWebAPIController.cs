using System;
using System.Linq;
using System.Web.Http;
using Prolog;
using UsingPrologAsRuleEngineOnASPNET.Models;

namespace UsingPrologAsRuleEngineOnASPNET.Controllers
{
    [RoutePrefix("api")]
    public class DefaultWebAPIController : ApiController
    {
        // POST api/can_marriage
        [HttpPost, Route("can_marriage")]
        public bool CanMarriage(QueryModel model)
        {
            var prolog = new PrologEngine(persistentCommandHistory: false);

            // ルール(Prologコード)の読み込み
            prolog.ConsultFromString(model.rule);

            // 求婚男性(仮名:john)のスペック(Prologコード)を定義
            var spec = model.man_spec;
            prolog.ConsultFromString(
                string.Format("spec(john, annual_income({0}), height({1}), class_curve({2}), wealthy_parent({3})).",
                spec.annual_income,
                spec.height,
                spec.class_curve,
                spec.wealthy_parent ? "yes" : "no"));

            // 問い合わせ ("john"は結婚できるか?) を実施
            var solution = prolog.GetFirstSolution("can_marrige(john).");

            // 結果を返す
            return solution.Solved;
        }
    }
}