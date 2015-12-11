'
'    App: PickRandomLine
' Author: Anthoni "Kalbintion" Wiese
'   Date: 2014 Sept 14
'
'   Desc: This application opens a given file through the command line and will pick a random line from it
'
'  Usage: PickRandomLine (-l text_1[ text_2[ text_3[...]]]| target_file)
Module modMain

    Sub Main()
        Dim argList() As String = Environment.GetCommandLineArgs
        Dim isInTextMode As Boolean = Not IsNothing(Array.Find(argList, Function(p) p = "-l"))

        If argList.Length = 1 Then
            printAppHelp()
            End
        End If

        If isInTextMode Then
            Dim random As New Random
            Console.WriteLine(argList(random.Next(2, argList.Length)))
        Else
            Try
                Dim fileContents = System.IO.File.ReadAllText(argList(1))
                Dim fileLines = fileContents.Split(Environment.NewLine)
                Dim random As New Random

                Console.WriteLine(fileLines(random.Next(0, fileLines.Length)))
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End If

    End Sub

    Sub printAppHelp()
        Console.WriteLine(My.Application.Info.AssemblyName & " (-l text_1[ text_2[ text_3[...]]]| target_file)")
        Console.WriteLine()
        Console.WriteLine("   target_file - The name of the file to open to pick a random line from")
        Console.WriteLine("   -l          - Picks a random line from the CLA instead of a file")
    End Sub
End Module
