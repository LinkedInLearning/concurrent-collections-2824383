# Advanced C#: Thread-Safe Data with Concurrent Collections
This is the repository for the **LinkedIn Learning** course **Advanced C#: Thread-Safe Data with Concurrent Collections**. The full course is available from [LinkedIn Learning][lil-course-url].



## .NET Essentials
.NET is a mature programming framework used around the world to build applications for every type of project.
Our .NET Essentials courses dig deep into a sub-section of .NET, given you a long look at one segment of this ubiquitous framework.
## This course topic
A "thread-safe" class is one whose members are protected from situations in which one thread interrupts another thread. The standard .NET collection types are not thread safe, which can lead to a slew of problems, including race conditions, data corruption, and unexpected exceptions in modern multithreaded applications. In this course, instructor Walt Ritscher demonstrates how to work with the thread-safe concurrent collections to share data across threads and build more scalable applications. Using practical examples, Walt outlines the problems you can face when working in multithreaded applications and explains why concurrent collections are great at handling multiple threads. He explores how to work with the ConcurrentDictionary class, including how to update data in ConcurrentDictionary. Plus, learn about the producer-consumer pattern and how it relates to concurrent collections types, how to use BlockingCollection—a thread-safe collection class—and more.

## Instructions
This repository has branches for each of the videos in the course. You can use the branch pop up menu in github to switch to a specific branch and take a look at the course at that stage, or you can add `/tree/BRANCH_NAME` to the URL to go to the branch you want to access.

## Branches
The branches are structured to correspond to the videos in the course. The naming convention is `chapter#-video#`. As an example, the branch named `02-03` corresponds to the second chapter and the third video in that chapter.
Some branches will have a beginning state (`04-01`) and an end state (`04-01e`). The end state videos use `e` for "end" and contains the code as it is at the end of the video. The `master` branch holds the the initial state of the course and is not used for exercises during the course.

## Installing
To use these exercise files, follow the instructions in the course to learn how to work with GitHub content.
For this course the instructor uses Visual Studio 2019 but older versions are acceptable, any edition is sufficient (Community, Professional, Enterprise). 

![Advanced C#: Thread-Safe Data with Concurrent Collections][lil-thumbnail-url] 
## About our .NET courses
When you are ready to [learn more about .NET](https://www.linkedin.com/learning/search?entityType=COURSE&keywords=.net) or [Visual Studio](https://www.linkedin.com/learning/search?entityType=COURSE&keywords=visual%20studio), **LinkedIn Learning** has what you need. 

## About the Instructor - Walt Ritscher
Check out my [other courses](https://www.linkedin.com/learning/instructors/walt-ritscher) on LinkedIn Learning.  Follow me on [LinkedIn](https://www.linkedin.com/in/waltritscher/?trk=lil_course) and [Twitter](https://twitter.com/waltritscher). 

[0]: # (Replace these placeholder URLs with actual course URLs)

[lil-course-url]: https://www.linkedin.com/learning/advanced-c-sharp-thread-safe-data-with-concurrent-collections
[lil-thumbnail-url]: https://cdn.lynda.com/course/2824383/2824383-1589992733519-16x9.jpg
