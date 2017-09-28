using System;
using System.Collections.Generic;
using System.Reflection;

namespace Exchange.Contracts.Services
{
    internal static class ServiceHelpers
    {
        /// <summary>
        /// gets all types that used by the subscription service
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetKnownSubscriptionTypes(ICustomAttributeProvider provider)
        {
            //use same types as publishing for now
            return GetKnownPublishingTypes(provider);
        }

        /// <summary>
        /// gets all types that are used by publishing service
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetKnownPublishingTypes(ICustomAttributeProvider provider)
        {
            List<Type> types = GetKnownMessageTypes();
            //types.Add(typeof(ProcessState));
            return types;
        }

        static List<Type> KnownMessageTypes;

        /// <summary>
        /// Gets all types that implement the IMessage interface.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        static List<Type> GetKnownMessageTypes()
        {
            if (KnownMessageTypes == null)
            {
                KnownMessageTypes = GetAllDerivedClasses(typeof(Message));
                KnownMessageTypes.Add(typeof(ProcessState));
            }
           
            return KnownMessageTypes;
        }

        /// <summary>
        /// Method to populate a list with all the classes that implement interface
        /// </summary>
        /// <param name="nameSpace">The type the user wants searched</param>
        /// <returns></returns>
        static List<Type> GetAllDerivedClasses(Type baseType)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            
            List<Type> returnList = new List<Type>();

            foreach (Type type in asm.GetTypes())
            {
                if (type != baseType && typeof(Message).IsAssignableFrom(type))
                    returnList.Add(type);
            }
            return returnList;
        }
    }
}
