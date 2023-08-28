# Planets

Application is solved as DLL library. 
So all you need is compile project and copy PlanetsUtil.dll to your own application.

There are also NUnit tests in the folder CRUD_UT_Tests.
This testing folder expects a PlanetsUtil.dll in its ./lib/ folder.

This solution is from recent version (branch develop) made as a facade. There are more strict access to other objects. Because of that, unit tests with this dll do not work. So, for functionality of testing, I let the original PlanetsUtil.dll in unit tests folder.

Todo: Tests.

Todo: Base class for 3 existing CRUD classes.

