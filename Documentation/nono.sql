create database project;
use database project;
go;


MYSQL:
create table employee_details(
    Emp_id varchar(8);
    first_name varchar(16);
    PRIMARY KEY (Emp_id)
)
CREATE TABLE project_details(
    projectid varchar(8),
    Emp_id varchar(8),
    PRIMARY KEY (projectid),
    F
);

SQL Server / Oracle:
create table employee_details(
    Emp_id varchar(8) NOT NULL PRIMARY KEY,
    first_name varchar(16),
)
CREATE TABLE project_details(
    projectid varchar(8) NOT NULL PRIMARY KEY,
    Emp_id varchar(8) FOREIGN KEY REFERENCES employee_details(Emp_id),
);

b)

INSERT INTO employee_details VALUES ("emp001", "Jagath", "Manuwarna", 100000000, "Edu", "female", "2001/10/10");
-- INSERT INTO employee_details (emp_id, fristname, latname, slalry, departyment) VALUES ("emp001", "Jagath", "Manuwarna", 100000000, "Edu");

c)
SELECT employee_details.firstname, employee_details.lastname, project_details.projectname from employee_details
INNER JOIN project_details on employee_details.emp_id = project_details.emp_id;

d)
SELECT employee_details.firstname, employee_details.lastname, project_details.projectname from employee_details
INNER JOIN project_details on employee_details.emp_id = project_details.emp_id WHERE COUNT(project_details.emp_id)>1 ;
