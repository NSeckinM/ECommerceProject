using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Common
{
    //Bu class diğer bütün classlarda da Id entitisi olduğu için miras alan classların hepsinde kullanılabilmesi amacıyla abstract olarak oluşturuldu
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }

    }
}
