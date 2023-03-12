using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PasswordBusiness: IPasswordBusiness
    {
        public async Task<int> goodPassword(string pwd)
        {
            var res = Zxcvbn.Core.EvaluatePassword(pwd);
            return res.Score;
        }
    }
}
