
using Cobra.Common.Threading.Extensions;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Cobra.Common
{
    /// <summary>
    /// Implements <see cref="T:Abp.IGuidGenerator" /> by creating sequential Guids.
    /// This code is taken from https://github.com/jhtodd/SequentialGuid/blob/master/SequentialGuid/Classes/SequentialGuid.cs
    /// </summary>
    public class SequentialGuidGenerator : IGuidGenerator
    {
        private readonly static RandomNumberGenerator Rng;

        public SequentialGuidGenerator.SequentialGuidDatabaseType DatabaseType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the singleton <see cref="T:Abp.SequentialGuidGenerator" /> instance.
        /// </summary>
        public static SequentialGuidGenerator Instance
        {
            get;
        }

        static SequentialGuidGenerator()
        {
            SequentialGuidGenerator.Instance = new SequentialGuidGenerator();
            SequentialGuidGenerator.Rng = RandomNumberGenerator.Create();
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="T:Abp.SequentialGuidGenerator" /> class from being created.
        /// Use <see cref="P:Abp.SequentialGuidGenerator.Instance" />.
        /// </summary>
        private SequentialGuidGenerator()
        {
            this.DatabaseType = SequentialGuidGenerator.SequentialGuidDatabaseType.SqlServer;
        }

        public Guid Create()
        {
            return this.Create(this.DatabaseType);
        }

        public Guid Create(SequentialGuidGenerator.SequentialGuidDatabaseType databaseType)
        {
            switch (databaseType)
            {
                case SequentialGuidGenerator.SequentialGuidDatabaseType.SqlServer:
                    {
                        return this.Create(SequentialGuidGenerator.SequentialGuidType.SequentialAtEnd);
                    }
                case SequentialGuidGenerator.SequentialGuidDatabaseType.Oracle:
                    {
                        return this.Create(SequentialGuidGenerator.SequentialGuidType.SequentialAsBinary);
                    }
                case SequentialGuidGenerator.SequentialGuidDatabaseType.MySql:
                    {
                        return this.Create(SequentialGuidGenerator.SequentialGuidType.SequentialAsString);
                    }
                case SequentialGuidGenerator.SequentialGuidDatabaseType.PostgreSql:
                    {
                        return this.Create(SequentialGuidGenerator.SequentialGuidType.SequentialAsString);
                    }
            }
            throw new InvalidOperationException();
        }

        public Guid Create(SequentialGuidGenerator.SequentialGuidType guidType)
        {
            byte[] numArray = new Byte[10];
            SequentialGuidGenerator.Rng.Locking<RandomNumberGenerator>((RandomNumberGenerator r) => r.GetBytes(numArray));
            DateTime utcNow = DateTime.UtcNow;
            byte[] bytes = BitConverter.GetBytes(utcNow.Ticks / (long)10000);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            byte[] numArray1 = new Byte[16];
            if (guidType <= SequentialGuidGenerator.SequentialGuidType.SequentialAsBinary)
            {
                Buffer.BlockCopy(bytes, 2, numArray1, 0, 6);
                Buffer.BlockCopy(numArray, 0, numArray1, 6, 10);
                if (guidType == SequentialGuidGenerator.SequentialGuidType.SequentialAsString && BitConverter.IsLittleEndian)
                {
                    Array.Reverse(numArray1, 0, 4);
                    Array.Reverse(numArray1, 4, 2);
                }
            }
            else if (guidType == SequentialGuidGenerator.SequentialGuidType.SequentialAtEnd)
            {
                Buffer.BlockCopy(numArray, 0, numArray1, 0, 10);
                Buffer.BlockCopy(bytes, 2, numArray1, 10, 6);
            }
            return new Guid(numArray1);
        }

        /// <summary>
        /// Database type to generate GUIDs.
        /// </summary>
        public enum SequentialGuidDatabaseType
        {
            SqlServer,
            Oracle,
            MySql,
            PostgreSql
        }

        /// <summary>
        /// Describes the type of a sequential GUID value.
        /// </summary>
        public enum SequentialGuidType
        {
            /// <summary>
            /// The GUID should be sequential when formatted using the
            /// <see cref="M:System.Guid.ToString" /> method.
            /// </summary>
            SequentialAsString,
            /// <summary>
            /// The GUID should be sequential when formatted using the
            /// <see cref="M:System.Guid.ToByteArray" /> method.
            /// </summary>
            SequentialAsBinary,
            /// <summary>
            /// The sequential portion of the GUID should be located at the end
            /// of the Data4 block.
            /// </summary>
            SequentialAtEnd
        }
    }
}