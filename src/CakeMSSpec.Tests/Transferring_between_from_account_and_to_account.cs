using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using Machine.Specifications.Model;

namespace CakeMSSpec.Tests
{
    [Subject(typeof(Account))]
    public class Transferring_between_from_account_and_to_account
    {
        static Account fromAccount;
        static Account toAccount;

        Establish context =
        () =>
        {
            fromAccount = new Account(1m);
            toAccount = new Account(1m);
        };

        Because of = () => fromAccount.Transfer(1m, toAccount);

        It should_debit_the_from_account_by_the_amount_transferred = () =>
        {
            fromAccount.Balance.ShouldEqual(0m);
        };

        It should_credit_the_to_account_by_the_amount_transferred = () =>
        {
            toAccount.Balance.ShouldEqual(2m);
        };
    }
}
