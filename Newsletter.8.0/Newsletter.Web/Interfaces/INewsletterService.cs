using GeniusChuck.Newsletter.Web.Models;

namespace GeniusChuck.Newsletter.Web.Interfaces
{
    // TODO: Changer la structure du projet par fonctionnalité plutôt que par namespace.
    public interface INewsletterService
    {
        List<Subscriber> GetSubscribers();
        int Subscribe(Subscriber subscriber);
        int Unsubscribe(string email);
    }
}
