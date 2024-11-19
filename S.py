#!/usr/bin/env python3
import rospy
from sensor_msgs.msg import Image
import numpy as np
import cv2, cv_bridge

class Follower:
    def __init__(self):
        self.bridge = cv_bridge.CvBridge()
        # cv2.namedWindow("original", 1)
        self.image_sub = rospy.Subscriber('camera/rgb/image_raw', Image, self.image_callback)


    def image_callback(self, msg):
        # image = self.bridge.imgmsg_to_cv2(msg,desired_encoding='bgr8')

        # image_resized = cv2.resize(image, (w//4,h//4))
        # cv2.imshow("original", image_resized)
        # cv2.waitKey(3)

        lightest = [40,100,20]
        darkest = [80,255,255]

        image = self.bridge.imgmsg_to_cv2(msg,desired_encoding='bgr8')
        (h, w) = image.shape[:2]
        cv2.namedWindow("original", 1)
        cv2.imshow("original", cv2.resize(image, (w//4,h//4)))

        hsv = cv2.cvtColor(image, cv2.COLOR_BGR2HSV)
        lightest = np.array(lightest, dtype = "uint8")
        darkest = np.array(darkest, dtype = "uint8")
        mask = cv2.inRange(hsv, lightest, darkest)
        output_image = cv2.bitwise_and(image, image, mask = mask)
        cv2.imshow("thresholded", cv2.resize(output_image, (w//4,h//4)))

        cv2.waitKey(5000)

rospy.init_node('follower')
follower = Follower()
rospy.spin()
