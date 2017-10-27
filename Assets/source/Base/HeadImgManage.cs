

/*************************安卓 IOS 打包代码************************************/

// package com.cheerflame.sdrn;  
  
// import java.io.File;  
// import java.io.FileNotFoundException;  
// import java.io.FileOutputStream;  
// import java.io.IOException;  
  
// import com.unity3d.player.UnityPlayer;  
// import com.unity3d.player.UnityPlayerActivity;  
  
// import android.content.Intent;  
// import android.graphics.Bitmap;  
// import android.net.Uri;  
// import android.os.Environment;  
// import android.provider.MediaStore;  
// import android.util.Log;  
  
// public class HeadImgManage{  
//     UnityPlayerActivity unityActivity;  
      
//     public static final int NONE = 0;  
//     public static final int PHOTOHRAPH = 1;// 拍照  
//     public static final int PHOTOZOOM = 2; // 缩放  
//     public static final int PHOTORESOULT = 3;// 结果    
//     public static final String IMAGE_UNSPECIFIED = "image/*";    
  
//     public final static String FILE_NAME = "image.jpg";  
//     public final static String DATA_URL = "/data/data/";  
      
//     public HeadImgManage(UnityPlayerActivity activity){  
//         unityActivity = activity;  
//     }  
      
//     public void TakePhoto(int choose)  
//     {  
//         if(choose == 0)  
//         {  
//             Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);  
//             intent.putExtra(MediaStore.EXTRA_OUTPUT, Uri.fromFile(new File(Environment.getExternalStorageDirectory(), "temp.jpg")));  
//             unityActivity.startActivityForResult(intent, PHOTOHRAPH);  
//         }  
//         else  
//         {  
//             Intent intent = new Intent(Intent.ACTION_PICK, null);  
//             intent.setDataAndType(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, IMAGE_UNSPECIFIED);  
//             unityActivity.startActivityForResult(intent, PHOTOZOOM);  
//         }  
//     }  
      
//     public void startPhotoZoom(Uri uri) {  
//         Log.i("TEST", "开始裁剪" + uri);  
          
//         Intent intent = new Intent("com.android.camera.action.CROP");  
//         intent.setDataAndType(uri, IMAGE_UNSPECIFIED);  
//         intent.putExtra("crop", "true");  
//         // aspectX aspectY 是宽高的比例  
//         intent.putExtra("aspectX", 1);  
//         intent.putExtra("aspectY", 1);  
//         // outputX outputY 是裁剪图片宽高  
//         intent.putExtra("outputX", 300);  
//         intent.putExtra("outputY", 300);  
//         intent.putExtra("return-data", true);  
//         unityActivity.startActivityForResult(intent, PHOTORESOULT);  
//     }    
  
//     public void SaveBitmap(Bitmap bitmap) throws IOException {  
//         Log.i("TEST", "保存文件");  
//                 FileOutputStream fOut = null;  
  
//                 //注解  
//                 String path = "/mnt/sdcard/Android/data/com.cheerflame.sdrn/files";  
//                 try {  
//                           //查看这个路径是否存在，  
//                           //如果并没有这个路径，  
//                           //创建这个路径  
//                           File destDir = new File(path);  
//                           if (!destDir.exists())  
//                           {  
//                                 destDir.mkdirs();  
//                           }  
  
//                         fOut = new FileOutputStream(path + "/" + FILE_NAME) ;  
//                         Log.i("TEST","保存路径" + path + "/" + FILE_NAME);  
//                         UnityPlayer.UnitySendMessage("Camera", "HeadImage","success!");  
//                         Log.i("TEST", "success");  
//                 } catch (FileNotFoundException e) {  
//                         e.printStackTrace();  
//                 }  
//                 //将Bitmap对象写入本地路径中，Unity在去相同的路径来读取这个文件  
//                 bitmap.compress(Bitmap.CompressFormat.JPEG, 10, fOut);  
//                 try {  
//                         fOut.flush();  
//                 } catch (IOException e) {  
//                         e.printStackTrace();  
//                 }  
//                 try {  
//                         fOut.close();  
//                 } catch (IOException e) {  
//                         e.printStackTrace();  
//                 }  
//         }  
  
// } 