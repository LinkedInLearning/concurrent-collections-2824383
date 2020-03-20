# C# Advanced: Thread-safe data with Concurrent Collections
This is the repository for the **LinkedIn Learning** course **C# Advanced:  Thread-safe data with Concurrent Collections**. The full course is available from [LinkedIn Learning](LICOURSEURL).


The standard .NET collection types are not thread safe which can lead to race conditions, data corruption and unexpected exceptions in modern multi-threaded applications. This course examines how to work with the thread-safe Concurrent Collections to share data across threads and build scalable applications. By default, the collections use a smart, efficient locking mechanism to ensure writing data is not compromised. Learn how to override the default locks when necessary.

## Instructions
This repository has branches for each of the videos in the course. You can use the branch pop up menu in github to switch to a specific branch and take a look at the course at that stage, or you can add `/tree/BRANCH_NAME` to the URL to go to the branch you want to access.

## Branches
The branches are structured to correspond to the videos in the course. The naming convention is `chapter#-video#`. As an example, the branch named `02-03` corresponds to the second chapter and the third video in that chapter.
Some branches will have a beginning state (`04-01`) and an end state (`04-01e`). The end state videos use `e` for "end" and contains the code as it is at the end of the video. The `master` branch holds the the initial state of the course and is not used for exercises during the course.

## Installing
To use these exercise files, follow the instructions in the course to learn how to work with GitHub content.
For this course the instructor uses Visual Studio 2019 but older versions are acceptable, any edition is sufficient (Community, Professional, Enterprise). 
