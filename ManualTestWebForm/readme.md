# ASP.NET WebFormsのカバレッジをOpenCoverで取得する方法

C:\Users\t_nii\source\repos\OpenCoverWebForm\OpenCoverWebForm>"C:\Users\t_nii\.nuget\packages\opencover\4.7.1221\tools\OpenCover.Console.exe"  -target:"C:\Program Files\IIS Express\iisexpress.exe" -targetargs:"/path:C:\Users\t_nii\source\repos\OpenCoverWebForm\OpenCoverWebForm /port:8081" -output:"C:\Users\t_nii\source\repos\OpenCoverWebForm\OpenCoverWebForm\obj\OpenCoverResult\reports.xml" -mergeoutput -register:user

C:\Users\t_nii\source\repos\OpenCoverWebForm\OpenCoverWebForm>C:\Users\t_nii\.nuget\packages\reportgenerator\4.8.10\tools\net47\ReportGenerator.exe -reports:"C:\Users\t_nii\source\repos\OpenCoverWebForm\OpenCoverWebForm\obj\OpenCoverResult\reports.xml" -reporttypes:HtmlInline; -targetdir:"C:\Users\t_nii\source\repos\OpenCoverWebForm\OpenCoverWebForm\obj\OpenCoverResult"

C:\Users\t_nii\AppData\Local\Temp\Temporary ASP.NET Files\root\dd07b728\73f75ce6\assembly\dl3\ce6bec55\19f7ae13_db6ad701

