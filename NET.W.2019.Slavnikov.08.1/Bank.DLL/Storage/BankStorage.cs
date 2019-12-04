using System;
using System.Collections.Generic;
using System.IO;
using Bank.DLL.Entities;
using static Bank.DLL.Storage.IStorage;

namespace Bank.DLL.Storage
{
    /// <summary>
    /// Class for saving and reading a coolection accounts to a file.
    /// </summary>
    public class BankStorage : IStorage
    {
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankStorage"/> class.
        /// </summary>
        /// <param name="path"> The path to the file.</param>
        public BankStorage(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"{path} is not correct!");
            }

            this.path = path;
        }

        /// <inheritdoc/>
        public IEnumerable<IAccount> Load()
        {
            List<IAccount> bankAccounts = new List<IAccount>();
            using (var binaryReader = new BinaryReader(File.Open(this.path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)))
            {
                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    string typeAccountString = binaryReader.ReadString();

                    TypesAccaount typeAccount = (TypesAccaount)Enum.Parse(typeof(TypesAccaount), typeAccountString, true);
                    switch (typeAccount)
                    {
                        case TypesAccaount.BaseAccount:
                            {
                                BaseAccount baseAccount = new BaseAccount()
                                {
                                    TypeAccount = typeAccountString,
                                    Id = binaryReader.ReadInt32(),
                                    Amount = binaryReader.ReadDecimal(),
                                    BonusPoints = binaryReader.ReadDecimal(),
                                    Status = binaryReader.ReadBoolean(),
                                };

                                UserInfo user = GetUser(binaryReader);
                                baseAccount.Client = user;
                                bankAccounts.Add(baseAccount);
                                break;
                            }

                        case TypesAccaount.GoldAccount:
                            {
                                GoldAccount goldAccount = new GoldAccount()
                                {
                                    TypeAccount = typeAccountString,
                                    Id = binaryReader.ReadInt32(),
                                    Amount = binaryReader.ReadDecimal(),
                                    BonusPoints = binaryReader.ReadDecimal(),
                                    Status = binaryReader.ReadBoolean(),
                                };

                                UserInfo user = GetUser(binaryReader);
                                goldAccount.Client = user;
                                bankAccounts.Add(goldAccount);
                                break;
                            }

                        case IStorage.TypesAccaount.PlattinumAccount:
                            {
                                PlattinumAccount plattinumAccount = new PlattinumAccount()
                                {
                                    TypeAccount = typeAccountString,
                                    Id = binaryReader.ReadInt32(),
                                    Amount = binaryReader.ReadDecimal(),
                                    BonusPoints = binaryReader.ReadDecimal(),
                                    Status = binaryReader.ReadBoolean(),
                                };

                                UserInfo user = GetUser(binaryReader);
                                plattinumAccount.Client = user;
                                bankAccounts.Add(plattinumAccount);
                                break;
                            }

                        default:
                            break;
                    }
                }
            }

            return bankAccounts;
        }

        /// <summary>
        /// Method for save collection a book to a file.
        /// </summary>
        /// <param name="accounts"> Saving collection.</param>
        public void Save(IEnumerable<IAccount> accounts)
        {
            if (accounts == null)
            {
                throw new ArgumentNullException($"accounts is null");
            }

            using var binaryWriter = new BinaryWriter(File.Open(this.path, FileMode.Create, FileAccess.Write, FileShare.None));
            foreach (IAccount book in accounts)
            {
                Writer(binaryWriter, book);
            }
        }

        private static UserInfo GetUser(BinaryReader binaryReader)
        {
            return new UserInfo()
            {
                Id = binaryReader.ReadInt32(),
                FirstName = binaryReader.ReadString(),
                LastName = binaryReader.ReadString(),
            };
        }

        private static void Writer(BinaryWriter binaryWriter, IAccount account)
        {
            binaryWriter.Write(account.TypeAccount);
            binaryWriter.Write(account.Id);
            binaryWriter.Write(account.Amount);
            binaryWriter.Write(account.BonusPoints);
            binaryWriter.Write(account.Status);
            binaryWriter.Write(account.Client.Id);
            binaryWriter.Write(account.Client.FirstName);
            binaryWriter.Write(account.Client.LastName);
        }
    }
}
