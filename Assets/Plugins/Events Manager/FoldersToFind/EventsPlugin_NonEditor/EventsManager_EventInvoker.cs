using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;



namespace Events.Groups {
namespace Level {
namespace Methods {
public interface IOnLevelEnd : Tools.IEventMethodBase{ void OnLevelEnd(); }
public interface IOnLevelStart : Tools.IEventMethodBase{ void OnLevelStart(); }

}public static class Invoke {
static List<Methods.IOnLevelEnd> _users_IOnLevelEnd  = new List<Methods.IOnLevelEnd>();
static List<Methods.IOnLevelStart> _users_IOnLevelStart  = new List<Methods.IOnLevelStart>();
internal static void RegisterUser(Methods.IOnLevelEnd user){
if(user == null) return;
if(!_users_IOnLevelEnd.Contains(user)) _users_IOnLevelEnd.Add(user);
}
internal static void UnRegisterUser(Methods.IOnLevelEnd user){
if(user == null) return;
if(_users_IOnLevelEnd.Contains(user)) _users_IOnLevelEnd.Remove(user);
}
public static void OnLevelEnd(){
_users_IOnLevelEnd.ForEach(x=> x.OnLevelEnd());   
}
internal static void RegisterUser(Methods.IOnLevelStart user){
if(user == null) return;
if(!_users_IOnLevelStart.Contains(user)) _users_IOnLevelStart.Add(user);
}
internal static void UnRegisterUser(Methods.IOnLevelStart user){
if(user == null) return;
if(_users_IOnLevelStart.Contains(user)) _users_IOnLevelStart.Remove(user);
}
public static void OnLevelStart(){
_users_IOnLevelStart.ForEach(x=> x.OnLevelStart());   
}

}public interface IAll_Group_Events:Methods.IOnLevelEnd,Methods.IOnLevelStart{ }

}namespace Fear {
namespace Methods {
public interface IFearDies : Tools.IEventMethodBase{ void FearDies(); }

}public static class Invoke {
static List<Methods.IFearDies> _users_IFearDies  = new List<Methods.IFearDies>();
internal static void RegisterUser(Methods.IFearDies user){
if(user == null) return;
if(!_users_IFearDies.Contains(user)) _users_IFearDies.Add(user);
}
internal static void UnRegisterUser(Methods.IFearDies user){
if(user == null) return;
if(_users_IFearDies.Contains(user)) _users_IFearDies.Remove(user);
}
public static void FearDies(){
_users_IFearDies.ForEach(x=> x.FearDies());   
}

}public interface IAll_Group_Events:Methods.IFearDies{ }

}
}


namespace Events {
public partial class Tools {
static partial void RegesterUserImplementation(object user)  {
if(!(user is Tools.IEventMethodBase))return; if(user is Groups.Level.Methods.IOnLevelEnd)
	Groups.Level.Invoke.RegisterUser(user as Groups.Level.Methods.IOnLevelEnd);
if(user is Groups.Level.Methods.IOnLevelStart)
	Groups.Level.Invoke.RegisterUser(user as Groups.Level.Methods.IOnLevelStart);
if(user is Groups.Fear.Methods.IFearDies)
	Groups.Fear.Invoke.RegisterUser(user as Groups.Fear.Methods.IFearDies);

}static partial void UnRegesterUserImplementation(object user)  {
if(!(user is Tools.IEventMethodBase))return; if(user is Groups.Level.Methods.IOnLevelEnd)
	Groups.Level.Invoke.UnRegisterUser(user as Groups.Level.Methods.IOnLevelEnd);
if(user is Groups.Level.Methods.IOnLevelStart)
	Groups.Level.Invoke.UnRegisterUser(user as Groups.Level.Methods.IOnLevelStart);
if(user is Groups.Fear.Methods.IFearDies)
	Groups.Fear.Invoke.UnRegisterUser(user as Groups.Fear.Methods.IFearDies);

}
}
}