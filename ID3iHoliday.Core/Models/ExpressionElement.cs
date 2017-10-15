using ID3iHoliday.Core.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Core.Models
{
    public abstract class ExpressionElement
    {
        protected virtual string Token { get; set; }
        public virtual string Expression => $@"{(Parent != null ?
                                                $@"{(string.IsNullOrEmpty(Token) ?
                                                        $"{Parent.Expression}"
                                                        : $"{Parent.Expression} ")}"
                                                : "")}{Token}";
        protected virtual ExpressionElement Parent { get; }

        protected virtual ParserBase Parser => Parent.Parser;
        public ExpressionElement(ExpressionElement parent) => Parent = parent;
        public ParserResult Parse(int year) => Parser.Parse(Expression, year);
    }
}
