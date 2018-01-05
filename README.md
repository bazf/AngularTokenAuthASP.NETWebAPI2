# AngularTokenAuthASP.NETWebAPI2

## Overview

Angular Token Authentication application using ASP.NET Web API 2 and Owin middleware.

Application allows users to do the following:
Register in the system by providing username and password.
Secure certain views from viewing by authenticated users (Anonymous users).
Allow registered users to log-in and keep them logged in for 30 minutes using tokens or until they log-out from the system, this is done using tokens.
System is role based (admin and user).
Used following front-end frameworks:
HTML/CSS,
Angular 2 rev 5.0.2,
Angular Material 2.0.0,
WebPack,
LESS.

## Default credentials for administrator

User Name: "administrator", Password: "administrator".
By default, after application start, the administrator user only exists in system. You can register new users in registration page. The password should not be less then 6 characters.

## EntityFramework DB Initializer 

For testing purpose, by default, custom EntityFramwork DB Initializer is setted to `DropCreateDatabaseAlways`. After every new application has been started data base is setted to its default values. You may want to change this behavior, so then you should uncomment needed custom initializer and comment others in NotesAppContext class's constructor.

## Build Server side.

Web project build starts with next pre-build events: 
	`echo "cd $(ProjectDir)notesApp" &&^
	cd "$(ProjectDir)notesApp" &&^
	echo "building notesApp" &&^
	npm run build`
If it crashes due to client build proccess, you might try to remove this commands and try again.

## Build Angular app

To build angular app run next command in cmd `npm run build` in "~\AngularTokenAuthASP.NETWebAPI2\WEB\notesApp" directory. This command implicity inits "webpack" command. You can observe all the rest commands in packake.json npm's file. If Client build proccess crashes, you can try to remove "node_modules" folder and run command `npm install`.

## Unit tests 

Running Jasmine tests via Karma tool: run in cmd `npm run test`. Server side BL's test are placed in project  named "Test" in solution.
