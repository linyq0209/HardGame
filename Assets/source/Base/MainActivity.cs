

/*************************安卓 IOS 打包代码************************************/

//在MainActivity中创建图片处理对象
//ImgManage = new HeadImgManage(this);


//正式启用后要加在MainActivity中接收事件请求回调

// protected void onActivityResult(int requestCode, int resultCode, Intent data) {  
//         Log.i("TEST", "requestCode = " + requestCode);  
//         if (resultCode == NONE){  
//             Log.i("TEST", "resultCode == NONE ");  
//             return;  
//         }  
              
//         if (requestCode == PHOTOHRAPH) {  
//             Log.i("TEST", "拍照完成");  
//             File picture = new File(Environment.getExternalStorageDirectory() + "/temp.jpg");  
//             ImgManage.startPhotoZoom(Uri.fromFile(picture));  
//         }    

//         if (data == null)  
//         {  
//             Log.i("TEST", "data == null");  
//             return;  
//         }  
                

//         // 读取相册缩放图片  
//         if (requestCode == PHOTOZOOM) {  
//             Log.i("TEST", "读取相册完成");  
//             ImgManage.startPhotoZoom(data.getData());  
//         }  
//         // 处理结果  
//         if (requestCode == PHOTORESOULT) {  
//             Bundle extras = data.getExtras();  
//             if (extras != null)   
//             {    
//                 Bitmap photo = extras.getParcelable("data");  
//                 try {  
//                     ImgManage.SaveBitmap(photo);         
//                 }   
//                 catch (IOException e)   
//                 {                     
//                     // TODO Auto-generated catch block                 
//                     e.printStackTrace();             
//                 }  
//             }    
//         }    
//         super.onActivityResult(requestCode, resultCode, data);  
//     }    

