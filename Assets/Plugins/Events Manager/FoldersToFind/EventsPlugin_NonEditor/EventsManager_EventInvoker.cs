using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;



namespace Events.Groups {
namespace Resetable {
namespace Methods {
public interface IResetInstance : Tools.IEventMethodBase{ void ResetInstance(); }

}public static class Invoke {
static List<Methods.IResetInstance> _users_IResetInstance  = new List<Methods.IResetInstance>();
internal static void RegisterUser(Methods.IResetInstance user){
if(user == null) return;
if(!_users_IResetInstance.Contains(user)) _users_IResetInstance.Add(user);
}
internal static void UnRegisterUser(Methods.IResetInstance user){
if(user == null) return;
if(_users_IResetInstance.Contains(user)) _users_IResetInstance.Remove(user);
}
public static void ResetInstance(){
_users_IResetInstance.ForEach(x=> x.ResetInstance());   
}

}public interface IAll_Group_Events:Methods.IResetInstance{ }

}namespace Pausable {
namespace Methods {
public interface IOnPause : Tools.IEventMethodBase{ void OnPause(); }
public interface IOnResume : Tools.IEventMethodBase{ void OnResume(); }

}public static class Invoke {
static List<Methods.IOnPause> _users_IOnPause  = new List<Methods.IOnPause>();
static List<Methods.IOnResume> _users_IOnResume  = new List<Methods.IOnResume>();
internal static void RegisterUser(Methods.IOnPause user){
if(user == null) return;
if(!_users_IOnPause.Contains(user)) _users_IOnPause.Add(user);
}
internal static void UnRegisterUser(Methods.IOnPause user){
if(user == null) return;
if(_users_IOnPause.Contains(user)) _users_IOnPause.Remove(user);
}
public static void OnPause(){
_users_IOnPause.ForEach(x=> x.OnPause());   
}
internal static void RegisterUser(Methods.IOnResume user){
if(user == null) return;
if(!_users_IOnResume.Contains(user)) _users_IOnResume.Add(user);
}
internal static void UnRegisterUser(Methods.IOnResume user){
if(user == null) return;
if(_users_IOnResume.Contains(user)) _users_IOnResume.Remove(user);
}
public static void OnResume(){
_users_IOnResume.ForEach(x=> x.OnResume());   
}

}public interface IAll_Group_Events:Methods.IOnPause,Methods.IOnResume{ }

}namespace Player {
namespace Methods {
public interface IOnHit_Int32 : Tools.IEventMethodBase{ void OnHit(System.Int32 currentPlayerHp); }
public interface IOnDie : Tools.IEventMethodBase{ void OnDie(); }
public interface IOnDashAvailable : Tools.IEventMethodBase{ void OnDashAvailable(); }

}public static class Invoke {
static List<Methods.IOnHit_Int32> _users_IOnHit_Int32  = new List<Methods.IOnHit_Int32>();
static List<Methods.IOnDie> _users_IOnDie  = new List<Methods.IOnDie>();
static List<Methods.IOnDashAvailable> _users_IOnDashAvailable  = new List<Methods.IOnDashAvailable>();
internal static void RegisterUser(Methods.IOnHit_Int32 user){
if(user == null) return;
if(!_users_IOnHit_Int32.Contains(user)) _users_IOnHit_Int32.Add(user);
}
internal static void UnRegisterUser(Methods.IOnHit_Int32 user){
if(user == null) return;
if(_users_IOnHit_Int32.Contains(user)) _users_IOnHit_Int32.Remove(user);
}
public static void OnHit(System.Int32 currentPlayerHp){
_users_IOnHit_Int32.ForEach(x=> x.OnHit(currentPlayerHp));   
}
internal static void RegisterUser(Methods.IOnDie user){
if(user == null) return;
if(!_users_IOnDie.Contains(user)) _users_IOnDie.Add(user);
}
internal static void UnRegisterUser(Methods.IOnDie user){
if(user == null) return;
if(_users_IOnDie.Contains(user)) _users_IOnDie.Remove(user);
}
public static void OnDie(){
_users_IOnDie.ForEach(x=> x.OnDie());   
}
internal static void RegisterUser(Methods.IOnDashAvailable user){
if(user == null) return;
if(!_users_IOnDashAvailable.Contains(user)) _users_IOnDashAvailable.Add(user);
}
internal static void UnRegisterUser(Methods.IOnDashAvailable user){
if(user == null) return;
if(_users_IOnDashAvailable.Contains(user)) _users_IOnDashAvailable.Remove(user);
}
public static void OnDashAvailable(){
_users_IOnDashAvailable.ForEach(x=> x.OnDashAvailable());   
}

}public interface IAll_Group_Events:Methods.IOnHit_Int32,Methods.IOnDie,Methods.IOnDashAvailable{ }

}namespace Level {
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
public interface IFearsFlee : Tools.IEventMethodBase{ void FearsFlee(); }

}public static class Invoke {
static List<Methods.IFearsFlee> _users_IFearsFlee  = new List<Methods.IFearsFlee>();
internal static void RegisterUser(Methods.IFearsFlee user){
if(user == null) return;
if(!_users_IFearsFlee.Contains(user)) _users_IFearsFlee.Add(user);
}
internal static void UnRegisterUser(Methods.IFearsFlee user){
if(user == null) return;
if(_users_IFearsFlee.Contains(user)) _users_IFearsFlee.Remove(user);
}
public static void FearsFlee(){
_users_IFearsFlee.ForEach(x=> x.FearsFlee());   
}

}public interface IAll_Group_Events:Methods.IFearsFlee{ }

}
}


namespace Events {
public partial class Tools {
static partial void RegesterUserImplementation(object user)  {
if(!(user is Tools.IEventMethodBase))return; if(user is Groups.Resetable.Methods.IResetInstance)
	Groups.Resetable.Invoke.RegisterUser(user as Groups.Resetable.Methods.IResetInstance);
if(user is Groups.Pausable.Methods.IOnPause)
	Groups.Pausable.Invoke.RegisterUser(user as Groups.Pausable.Methods.IOnPause);
if(user is Groups.Pausable.Methods.IOnResume)
	Groups.Pausable.Invoke.RegisterUser(user as Groups.Pausable.Methods.IOnResume);
if(user is Groups.Player.Methods.IOnHit_Int32)
	Groups.Player.Invoke.RegisterUser(user as Groups.Player.Methods.IOnHit_Int32);
if(user is Groups.Player.Methods.IOnDie)
	Groups.Player.Invoke.RegisterUser(user as Groups.Player.Methods.IOnDie);
if(user is Groups.Player.Methods.IOnDashAvailable)
	Groups.Player.Invoke.RegisterUser(user as Groups.Player.Methods.IOnDashAvailable);
if(user is Groups.Level.Methods.IOnLevelEnd)
	Groups.Level.Invoke.RegisterUser(user as Groups.Level.Methods.IOnLevelEnd);
if(user is Groups.Level.Methods.IOnLevelStart)
	Groups.Level.Invoke.RegisterUser(user as Groups.Level.Methods.IOnLevelStart);
if(user is Groups.Fear.Methods.IFearsFlee)
	Groups.Fear.Invoke.RegisterUser(user as Groups.Fear.Methods.IFearsFlee);

}static partial void UnRegesterUserImplementation(object user)  {
if(!(user is Tools.IEventMethodBase))return; if(user is Groups.Resetable.Methods.IResetInstance)
	Groups.Resetable.Invoke.UnRegisterUser(user as Groups.Resetable.Methods.IResetInstance);
if(user is Groups.Pausable.Methods.IOnPause)
	Groups.Pausable.Invoke.UnRegisterUser(user as Groups.Pausable.Methods.IOnPause);
if(user is Groups.Pausable.Methods.IOnResume)
	Groups.Pausable.Invoke.UnRegisterUser(user as Groups.Pausable.Methods.IOnResume);
if(user is Groups.Player.Methods.IOnHit_Int32)
	Groups.Player.Invoke.UnRegisterUser(user as Groups.Player.Methods.IOnHit_Int32);
if(user is Groups.Player.Methods.IOnDie)
	Groups.Player.Invoke.UnRegisterUser(user as Groups.Player.Methods.IOnDie);
if(user is Groups.Player.Methods.IOnDashAvailable)
	Groups.Player.Invoke.UnRegisterUser(user as Groups.Player.Methods.IOnDashAvailable);
if(user is Groups.Level.Methods.IOnLevelEnd)
	Groups.Level.Invoke.UnRegisterUser(user as Groups.Level.Methods.IOnLevelEnd);
if(user is Groups.Level.Methods.IOnLevelStart)
	Groups.Level.Invoke.UnRegisterUser(user as Groups.Level.Methods.IOnLevelStart);
if(user is Groups.Fear.Methods.IFearsFlee)
	Groups.Fear.Invoke.UnRegisterUser(user as Groups.Fear.Methods.IFearsFlee);

}
}
}