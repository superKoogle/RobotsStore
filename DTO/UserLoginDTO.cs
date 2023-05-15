using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserLoginDTO
    {

        [StringLength(maximumLength: 12, ErrorMessage = "too long password")]
        public string UserPassword { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string UserEmail { get; set; } = null!;
    }
}