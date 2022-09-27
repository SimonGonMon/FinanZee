using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FinanZee_WPF.Repositories;
using Newtonsoft.Json;

namespace FinanZee_WPF.Models
{
    public class TransactionModel
    {
        public class Transaction
        {
            public DateTime date { get; set; }
            public string type { get; set; }
            public double amount { get; set; }
        }

        public class TransactionManagement
        {
            public void UploadTransaction(Transaction transaction)
            {
                string serializedTransaction = JsonConvert.SerializeObject(transaction);

                UserRepository userRepository = new UserRepository();
                userRepository.InsertTransaction(serializedTransaction);
            }

            public ArrayList DownloadTransactions()
            {
                var transactionsArray = new ArrayList();
                UserRepository userRepository = new UserRepository();
                string[] transactions = (string[])userRepository.GetTransactions().ToArray(typeof(string));

                for(int i =0; i<transactions.Length;i++)
                {
                    transactionsArray.Add(JsonConvert.DeserializeObject<Transaction>(transactions[i]));       
                }

                return transactionsArray;

            }

        }
        



    }
}
