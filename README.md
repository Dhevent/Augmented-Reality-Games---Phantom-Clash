# Phantom Clash - Augmented Reality Card Battler ⚔️🂠

**Phantom Clash** is an Augmented Reality (AR) card-battling game built with Unity and Vuforia. Players scan physical target cards to summon animated 3D monsters into the real world and engage in tactical, turn-based combat.

---

## 🎥 Demo Video

Check out the gameplay in action:

[![Phantom Clash Demo](https://img.youtube.com/vi/YOUR_YOUTUBE_VIDEO_ID/maxresdefault.jpg)](https://www.youtube.com/watch?v=YOUR_YOUTUBE_VIDEO_ID)

*(Ganti `YOUR_YOUTUBE_VIDEO_ID` dengan ID video YouTube kamu, atau drag & drop file video MP4 kamu langsung ke editor README di GitHub)*

---

## 🎮 Core Mechanics

Combat relies on a predictive **Triangle Counter System**. Victory requires reading opponent patterns and selecting attack types wisely:

* ⚡ **Speed Attack:** Rapid strikes. Interrupts **Power Attack**, but gets reflected by **Guard**.
* 💥 **Power Attack:** High-damage blows. Crushes through **Guard**, but gets interrupted by **Speed Attack**.
* 🛡️ **Guard / Counter:** Defensive maneuver. Blocks & reflects **Speed Attack**, but gets shattered by **Power Attack**.

---

## 🛠️ Tech Stack

* **Game Engine:** Unity (2022.3 LTS or newer recommended)
* **AR SDK:** Vuforia Engine
* **Language:** C#
* **Target Platform:** Android / Desktop (Editor Testing)

---

## 🚀 Getting Started

### Prerequisites
1. **Unity Hub** & Unity Editor installed.
2. **Android Build Support** module installed in Unity (if building for mobile).
3. **Webcam** (for testing directly on PC) or an **Android Device** with USB Debugging enabled.

---

## 💻 How to Open & Play

### Option 1: Testing via Unity Editor (PC + Webcam)

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/Dhevent/Augmented-Reality-Games---Phantom-Clash.git](https://github.com/Dhevent/Augmented-Reality-Games---Phantom-Clash.git)
   cd Augmented-Reality-Games---Phantom-Clash
   
2. **Open in Unity Hub:**
   * Launch **Unity Hub**.
   * Click **Add** -> **Add project from disk**.
   * Select the cloned `Phantom Clash` project folder.
   * Open the project with your Unity Editor version.

3. **Open the Game Scene:**
   * In the Project panel, go to `Assets/Scenes/`.
   * Double-click `MainScene.unity` (or your main game scene).
     
4. **Run & Test:**
   * Ensure your webcam is connected.
   * Press the **Play** ▶️ button at the top of the Unity Editor.
   * Point your webcam at the physical card target images to spawn 3D monsters and start fighting.

### Option 2: Building & Playing on Android Device

1. Open the project in Unity Editor.
2. Go to **File > Build Settings**.
3. Select **Android** under Platform and click **Switch Platform**.
4. Connect your Android phone via USB cable (Enable Developer Mode & USB Debugging on your phone).
5. Click **Build and Run** to compile and automatically install the APK on your device.

---

## 🎴 Target Cards & Assets

Printable target cards used for scanning can be found inside the project directory:
* `Marker`

Open these image files on another screen or print them on paper, then scan them using your camera during gameplay.
