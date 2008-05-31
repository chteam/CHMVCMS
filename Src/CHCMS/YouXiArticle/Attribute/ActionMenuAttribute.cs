using System;

namespace YouXiArticle
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ActionMenuAttribute : ActionTypeAttribute
    {
        public ActionMenuAttribute() : base(ActionType.Menu) { }
        public string Title { get; set; }
    }
}
