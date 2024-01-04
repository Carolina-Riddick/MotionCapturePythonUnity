import cv2
from cvzone.PoseModule import PoseDetector

#  x1, y1, z1, x2, y2, z2,
cap = cv2.VideoCapture('Video.mp4')

detector = PoseDetector()
positionList = []

while True:
    success, img = cap.read()
    img = detector.findPose(img)
    lmList, boundingBoxInfo = detector.findPosition(img, bboxWithHands=False)

    # Detected Body
    if boundingBoxInfo:
        lmString = ''
        for landMark in lmList:
            lmString += f'{landMark[1]}, {img.shape[0] - landMark[2]}, {landMark[3]},'
        positionList.append(lmString)

    print(len(positionList)) # FPS

    cv2.imshow("Image", img)
    key = cv2.waitKey(1)
    if key == ord('s'):
        with open("AnimationMotionCaptureFile.txt", 'w') as f:
            f.writelines(["%s\n" % item for item in positionList])
