# WGU_MobileDevelopment_JMBenitez


Competencies
4026.2.1 : Introduction to Mobile Development

The graduate develops a simple mobile application using an integrated development environment (IDE).

4026.2.2 : User Interfaces

The graduate develops a user interface for a mobile application.

4026.2.3 : Managing Data

The graduate creates solutions to store, retrieve, and transmit mobile application data.

4026.2.4 : Supporting Devices and Platforms

The graduate develops an application that accounts for different platforms and device conditions.






Introduction
As a competent mobile application developer, your understanding of mobile application structure and design will help you to develop applications to meet customer requirements.



For this task, you will develop a multiple-screen mobile application for WGU students to track their academic terms, courses associated with each term, and assessments associated with each course. The application will allow students to enter, edit, and delete term, course, and assessment data. It should provide summary and detailed views of courses for each term, provide notifications for upcoming performance and objective assessments, and notify students of deadlines and tracking milestones even after the application is closed. You will create a wireframe as a visual guide, representing the skeletal framework of the application. Your application will use an SQLite database using the SQLIte ORM located at SQLite-net.



You will share this project to your GitLab repository and backup regularly. Use the GitLab link in the web links section to create your Gitlab project in the WGU GitLab space, and prior to starting your work, reference the “GitLab How-To” web link to set up your project.



This task will allow you to demonstrate your ability to apply the skills learned in the course and help you to apply these skills in a familiar, real-world scenario.



The assessment must be submitted using the NET Multi-platform App UI (MAUI) framework. For this assessment, you are welcome to use these plugins or plugins referenced at these sites:



.NET Multi-platform App UI (.NET MAUI) Community Toolkit Documentation

DatePicker

.NET MAUI Local Databases

Picker

Plugin.LocalNotification

Share

SQL tite-net



Any controls specified as part of the Microsoft .NET MAUI Toolkit are allowed in the project. All other external plugins and libraries are not allowed.






Requirements
Your submission must be your original work. No more than a combined total of 30% of the submission and no more than a 10% match to any one individual source can be directly quoted or closely paraphrased from sources, even if cited correctly. The similarity report that is provided when you submit your task can be used as a guide.



You must use the rubric to direct the creation of your submission because it provides detailed criteria that will be used to evaluate your work. Each requirement below may be evaluated by more than one rubric aspect. The rubric aspect titles may contain hyperlinks to relevant portions of the course.



Note: You will be submitting pictures, graphics, and/or diagrams. Each picture, graphic, and/or diagram should be an attachment no larger than 30 MB in size. Diagrams should be original and may be hand-drawn or drawn using a graphics program. CAD programs should not be used because attachments will be too large.



A.   Create a GitLab repository for your subgroup and project. Commit with a message and push when you complete each requirement listed in parts B1, B2, B3, C1, C2, C3, C4, C5, and C6. Submit both of the following:

  •   the GitLab repository URL

  •   a copy of the repository branch history retrieved from your repository, which must include all the commit messages and dates





Note:You may commit and push whenever you want to back up your changes, even if a requirement is not yet complete. Wait until you have completed all the following prompts before you create your copy of the repository branch history.


B.  Draw a low-fidelity wireframe for your mobile application that includes all of the following requirements:

1.  Add as many academic terms as needed; each term should include the addition, editing, deletion, and storage of all the following:

•   the term title

•   start and anticipated end dates (using a date picker)

2.  Add six courses for each term. For each course, include the addition, editing, deletion, and storage of all the following course information:

•   course name

•   start and anticipated end dates (using a date picker)

•   course status (using a picker)

•   course instructor’s information: name, phone, and email

•   add, share, and display optional notes

•   set notifications for the start and end dates of each course

•   display of a detailed view of each course, including the due date

•   editing of the detailed course view screen

3.  Add two assessments for each course. Each assessment should include the addition, editing, deletion, and storage of all the following assessment information:

•   one objective assessment

•   one performance assessment

•   names of both assessments

•   notifications for the start and end dates of both assessments





Note: For any editing dates shown in the wireframe, use a date picker and make it clear the dates being edited are using a date picker and not a text box for data editing. Additionally, when using other pickers in editing mode, be sure those are clearly pickers and not textboxes.


C.  Create, within the .NET Multi-platform App UI (MAUI) framework, a mobile application aligned to the wireframe drawn in part A. Include all of the following features:

1.  Provide an interface for all the following information for as many academic terms as needed:

 •   academic term title (e.g., Term 1, Term 2, Spring term)

 •   start and end dates (using a date picker)


Note: You are welcome to use the following plugin for this step: DatePicker


2.  Provide an interface that allows the user to access all the following features for each academic term:

 •   add and display a list of six courses for each term

 •   display a detailed view of each term, including all the information from part C1

3.  Provide an interface that allows the user to access and edit all the following details for each course:

 •   course title

 •   start and anticipated end dates (using a date picker)


Note: You are welcome to use the following plugin for this step: DatePicker


 •   course status (e.g., in progress, completed, dropped, plan to take) (using a picker)


Note: You are welcome to use the following plugin for this step: Picker


 •   the course instructor’s name, phone number, and email address; include validation to prevent the user from saving a null value (e.g., an invalid email address





4.  Create features that allow the user to do all of the following for each course:

 •   enter two assessments: one performance assessment and one objective assessment

 •   add and display optional notes

 •   enter, edit, and delete course information

 •   display an editable detailed view of the course, including the due date

 •   set alerts (e.g., notifications) for the start and end date of the course


Note: You are welcome to use the following plugin for this step: Plugin.LocalNotification


 •   share notes via a sharing feature (e.g., email, SMS)


Note: You are welcome to use the following plugins for this step: Share





5.  Provide an interface for the user to do all of the following for each assessment:

 •   include the names and due dates

 •   enter, edit, and delete assessment information

 •   set notifications for anticipated start and end dates of each assessment


Note: You are welcome to use the following plugin for this step: Plugin.LocalNotification





6.  Write code to create a set of data for evaluation purposes, including the following details:

 •   one term and one course from part C3

 •   the two assessments from part C4 for that course

 •   the following name, phone number, and email address as the course instructor contact information:

 •   Anika Patel

 •   555-123-4567

 •   anika.patel@strimeuniversity.edu





D.  Examine the wireframe from part B to determine any changes that you made during the development of the mobile application.

1.  Explain the reasons for any changes made during the development of the mobile application by adding comments within the wireframe. If no changes were made, include that comment.

2.  Confirm that the wireframe aligns with the completed mobile application from part C after the inclusion of the comments from part D1.




	1. 
E.  Provide a complete and operational source file for your mobile application.


F.  Demonstrate professional communication in the content and presentation of your submission.