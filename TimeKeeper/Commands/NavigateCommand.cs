using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.Services;

namespace TimeKeeper.Commands
{
    public class NavigateCommand : CommandBase
    {
        /// <summary>
        /// Navigation service whose <see cref="INavigate.Navigate"/>
        /// method is to be called.
        /// </summary>
        private readonly INavigate _navigationService;


        /// <summary>
        /// Initializes a new instance of the
        /// <seealso cref="NavigateCommand"/> class.
        /// </summary>
        /// <param name="navigationService"></param>
        public NavigateCommand(INavigate navigationService)
        {
            _navigationService = navigationService;
        }


        /// <summary>
        /// Calls the <see cref="INavigate.Navigate"/> method of
        /// <seealso cref="_navigationService"/> instance.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
