# WidowGamesChallenge
 This is a challenge made for the awesome Widow Games Company :)

# Third Party Plugins
 
 To be honest I haven't had problems when importing third party plugins. In my case I just drag this plugins to the asset folder of my project. Once Unity recognize it, I change settings from inspector. Most common issue I have is related to Android SDK and NDK. It's common to have some missing folders in PlaybackEngines folder.
 
 # Bulding with TestFlight
 
 1. You should set your project to iOS platform, have XCode downloaded and also being part of Apple Developer program to have access to TestFlight.
 2. If your project is ready to build, before shot "Build" you might want to review some fields on Proyect Settings-Player as version, bundle identfier, etc. 
 3. Save our build localy
 4. Once the process is finished we should go to the build folder and double click on XCode file.
 5. Check and set configuration. If you did't add your Apple ID yet, you should go to preferences and add it.
 6. Select "Any iOS Device" and click "Archive" on "Product" -> Distribute App -> "App Store Connect" -> Upload
 7. Generate Cerificate of our App.
 8. Press Upload!
 9. Now we should go to App Store Connect and Log in -> Go to TestFlight and we should see our App.
