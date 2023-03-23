using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEditor;
using UnityEngine;

public class CopyFilesToStreamingAssets : Editor
{
    static string sourceDirectory = Application.dataPath+"/../"+"ABs/Package";
    static string  destinationDirectory = Application.streamingAssetsPath;
    static string maxVersionFolderName = "0_0_0_0";
    
    [MenuItem("Tools/Delete StreamingAssets")]
    public static void DeleteStreamingAseetsFiles()
    {
        if (Directory.Exists(destinationDirectory))
        {
            DirectoryInfo dirInfo = new DirectoryInfo(destinationDirectory);
            FileInfo[] files = dirInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                if (!file.Name.EndsWith(".meta"))
                {
                    file.Delete();
                }
            }
            AssetDatabase.Refresh();

            Debug.Log("Deleted all files in StreamingAssets directory.");
        }
        else
        {
            Debug.Log(destinationDirectory+"文件夹不存在");
        }
    }
    // [MenuItem("Tools/Copy PC Files To StreamingAssets")]
    public static void CalculateFiles()
    {
        // Get the source directory based on the current platform

        // Get the destination directory

        // Delete all files in the destination directory
        if (Directory.Exists(destinationDirectory))
        {
            DirectoryInfo di = new DirectoryInfo(destinationDirectory);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
        else
        {
            Directory.CreateDirectory(destinationDirectory);
        }
        // 删除StreamingAssets下的所有文件
        string streamingAssetsPath = Application.streamingAssetsPath;
        DirectoryInfo dirInfo = new DirectoryInfo(streamingAssetsPath);
        foreach (FileInfo file in dirInfo.GetFiles())
        {
            file.Delete();
        }
        foreach (DirectoryInfo dir in dirInfo.GetDirectories())
        {
            dir.Delete(true);
        }

        // 找到最大版本号的文件夹
        DirectoryInfo sourceFolder = new DirectoryInfo(sourceDirectory);
        DirectoryInfo[] dirs = sourceFolder.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            string[] dirNameParts = dir.Name.Split('_');
            string[] maxVersionParts = maxVersionFolderName.Split('_');
            if (dirNameParts.Length == 4 && maxVersionParts.Length == 4)
            {
                int dirVersion = 0;
                int maxVersion = 0;
                for (int i = 0; i < 4; i++)
                {
                    int.TryParse(dirNameParts[i], out dirVersion);
                    int.TryParse(maxVersionParts[i], out maxVersion);
                    if (dirVersion > maxVersion)
                    {
                        maxVersionFolderName = dir.Name;
                        break;
                    }
                }
            }
        }
        Debug.Log("当前最大的版本号是----"+maxVersionFolderName);
    }

    [MenuItem("Tools/Copy Files To StreamingAssets/Win")]
    public static void CopyPCWinFiles()
    {
        CalculateFiles();
        sourceDirectory = Application.dataPath+"/../"+"ABs/Package/"+maxVersionFolderName+"/Windows";
        Debug.Log("当前拷贝的路径是---"+sourceDirectory);
        // Copy files from source directory to destination directory
        foreach (string file in Directory.GetFiles(sourceDirectory))
        {
            string fileName = Path.GetFileName(file);
            string dest = Path.Combine(destinationDirectory, fileName);
            File.Copy(file, dest, true);
        }

        // Refresh asset database to reflect the changes
        AssetDatabase.Refresh();
    }
    
    [MenuItem("Tools/Copy Files To StreamingAssets/Win64")]
    public static void CopyPCWin64Files()
    {
        CalculateFiles();
        sourceDirectory = Application.dataPath+"/../"+"ABs/Package/"+maxVersionFolderName+"/Windows64";
        Debug.Log("当前拷贝的路径是---"+sourceDirectory);
        // Copy files from source directory to destination directory
        foreach (string file in Directory.GetFiles(sourceDirectory))
        {
            string fileName = Path.GetFileName(file);
            string dest = Path.Combine(destinationDirectory, fileName);
            File.Copy(file, dest, true);
        }

        // Refresh asset database to reflect the changes
        AssetDatabase.Refresh();
    }
    
    [MenuItem("Tools/Copy Files To StreamingAssets/IOS")]
    public static void CopyIOSFiles()
    {
        CalculateFiles();
        sourceDirectory = Application.dataPath+"/../"+"ABs/Package/"+maxVersionFolderName+"/IOS";
        Debug.Log("当前拷贝的路径是---"+sourceDirectory);
        // Copy files from source directory to destination directory
        foreach (string file in Directory.GetFiles(sourceDirectory))
        {
            string fileName = Path.GetFileName(file);
            string dest = Path.Combine(destinationDirectory, fileName);
            File.Copy(file, dest, true);
        }

        // Refresh asset database to reflect the changes
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/Copy Files To StreamingAssets/Android")]
    public static void CopyAndroidFiles()
    {
        CalculateFiles();
        sourceDirectory = Application.dataPath+"/../"+"ABs/Package/"+maxVersionFolderName+"/Android";
        Debug.Log("当前拷贝的路径是---"+sourceDirectory);
        // Copy files from source directory to destination directory
        foreach (string file in Directory.GetFiles(sourceDirectory))
        {
            string fileName = Path.GetFileName(file);
            string dest = Path.Combine(destinationDirectory, fileName);
            File.Copy(file, dest, true);
        }

        // Refresh asset database to reflect the changes
        AssetDatabase.Refresh();
    }
}
