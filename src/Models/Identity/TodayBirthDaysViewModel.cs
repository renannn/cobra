using Cobra.Entities.Administration;
using System.Collections.Generic;

namespace Cobra.Models.Identity
{
    public class TodayBirthDaysViewModel
    {
        public List<User> Users { set; get; }

        public AgeStatViewModel AgeStat { set; get; }
    }
}