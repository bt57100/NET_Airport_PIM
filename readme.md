# .NET PIM Project

## Content
* <a href="#intro">I. Introduction</a>
* <a href="#bonus">II. Additional content</a>
* <a href="#install">III. Installation instruction</a>
  * <a href="#gene">III.A. General</a>
  * <a href="#conf">III.B. Configuration</a>
* <a href="#run">IV. Running instruction</a>
* <a href="#contrib">V. Contributors</a>
* <a href="#license">VI. License</a>

<a name="intro"></a>
### I. Introduction
The Airport PIM project aims at reproducing a reduced version of a PIM service
in an airport. The project will be implemented in **C#/.NET** using
**Visual Studio** and an **SQL SERVER** database. The database is provided.  
At the very least:
  *  The project should implement a *client/server* design: the only link between
  both should be a WCF service.
  * The server side should contain a *factory* to choose the type of database
(native or sql).
  * The client side should provide a *good user experience*.
  * The client form should enable *searching and displaying* luggage using iata
  code or id.
  * The client form should enable *creating* a new luggage.

<a name="bonus"></a>
### II. Additional content
* **Exception management**:
  * A *MultipleFaultException* is thrown by the server when there are more than
  one BagageDefinition found using iata code. A form is then opened on client
  side to select the corresponding luggage.
  * A *FaultException* is thrown when the client try to create a new luggage with
  a non-existant company iata code.
* When an error occurred on the server, it is possible to **recreate** it.
* **Update** is possible. Note that the creation date and the company cannot be
changed logically speaking.
* Before creating a luggage, the *iata code format* is checked.
* After the creation of a luggage, the **new luggage id** is displayed.
* The **number of character** is checked, directly in the form.
* When creating or updating a luggage, if luggage is in rush, an entry is
created/removed in **BAGAGE_A_POUR_DEFINITION** table.
* The **tab index** are manage for both client and server form.
* Some items are responsive.

*Note that when updating, as long as there is something in the priority the
luggage is considered to have a priority. Empty it to make the luggage remove
the priority.*

<a name="install"></a>
### III. Installation instruction
<a name="gene"></a>
#### III. A. General
1. Clone it from git hub.  
2. Import it in VisualStudio using solution name `MyAirport.Pim`.

<a name="conf"></a>
#### III. B. Configuration

The current database is `.\SQLSERVER`.  
If needed, change the database access in `App.config`.

<a name="run"></a>
### IV. Running instruction
1. On the server form, click on **Create** button.
2. The button **Open** becomes accessible. Click on it.
3. The status should be `Opened`. The server side is set.
4. Then, you can use the client form.

*Note that if the previous instructions are not correctly followed. The client for will
always display a message in the bottom of the form to signal the problem to
connect to the server. By the way, if an error occurred the server form 
enables to create a new instance.*

<a name="contrib"></a>
### V. Contributors
* Kevin GUOI

<a name="license"></a>
### VI. License
* ISC
