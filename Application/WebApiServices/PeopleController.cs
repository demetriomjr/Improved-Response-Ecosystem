using Application.Interfaces;
using Models.People;
using RabbitHelper;

namespace Application.WebApiServices
{
    public class PeopleController : IWebAPIContext<Person>
    {
        public async Task<List<Person>> Get(Func<Person, bool> predicate, CToken ct)
        {
            await RabbitHelperService.PublishOnQueueAsync<List<Person>>(predicate, ct, (result, ctResult) =>
            {
                return Task.FromResult(result);
            });

            return [];
        }

        public async Task<Person?> Get(uint id, CToken ct)
        {
            await RabbitHelperService.PublishOnQueueAsync<Person>(id, ct, (result, ctResult) =>
            {
                return Task.FromResult(result);
            });

            return null!;
        }

        public async Task<Person> Post(Person item, CToken ct)
        {
            await RabbitHelperService.PublishOnQueueAsync<Person>(item, ct, (result, ctResult) =>
            {
                return Task.FromResult(result);
            });
            return null!;
        }

        public async Task<bool> Put(Person item, CToken ct)
        {
            await RabbitHelperService.PublishOnQueueAsync<bool>(item, ct, (result, ctResult) =>
            {
                return Task.FromResult(result);
            });
            return false;
        }

        public async Task<bool> Delete(uint id, CToken ct)
        {
            await RabbitHelperService.PublishOnQueueAsync<bool>(id, ct, (result, ctResult) =>
            {
                return Task.FromResult(result);
            });
            return false;
        }
    }
}
