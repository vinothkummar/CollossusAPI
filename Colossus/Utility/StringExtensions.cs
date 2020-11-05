using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colossus.Utility
{
    public static class StringExtensions
    {
        private enum UnescapeState
        {
            Unescaped,
            Escaped
        }

        public static String Unescape(this String s)
        {
            var sb = new System.Text.StringBuilder();
            UnescapeState state = UnescapeState.Unescaped;

            foreach (var ch in s)
            {
                switch (state)
                {
                    case UnescapeState.Escaped:
                        switch (ch)
                        {
                            case 't':
                                sb.Append('\t');
                                break;
                            case 'n':
                                sb.Append('\n');
                                break;
                            case 'r':
                                sb.Append('\r');
                                break;

                            case '\\':
                            case '\"':
                                sb.Append(ch);
                                break;

                            default:
                                throw new Exception("Unrecognized escape sequence '\\" + ch + "'");
                        }
                        state = UnescapeState.Unescaped;
                        break;

                    case UnescapeState.Unescaped:
                        if (ch == '\\')
                        {
                            state = UnescapeState.Escaped;
                        }
                        else
                        {
                            sb.Append(ch);
                        }
                        break;
                }
            }

            if (state == UnescapeState.Escaped)
            {
                throw new Exception("Unterminated escape sequence");
            }

            return sb.ToString();
        }
    }
}
