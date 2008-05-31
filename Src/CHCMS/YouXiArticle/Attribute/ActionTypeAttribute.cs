using System;
using System.Collections.Generic;

namespace YouXiArticle
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ActionTypeAttribute : Attribute
    {
        List<ActionType> _actionTypeList = new List<ActionType>();
        public ActionTypeAttribute(params ActionType[] at)
        {
            foreach (ActionType a in at)
            {
                _actionTypeList.Add(a);
            }
        }
    }
}
