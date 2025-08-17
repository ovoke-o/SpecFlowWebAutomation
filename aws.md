## Scenario: Solving the Team communication and instant messaging problem

<p>Team communication and instant messaging solutions are an integral part of any business environment today. As of 2020, the total number of users of Slack and Microsoft Teams exceeded 20 million. Some organizations might have compliance policies in place which do not allow them to use services managed by third parties. They will prefer solutions that can be managed and hosted on servers controlled by them. The same will extend to communication solutions as well.</p>

---

## 🧰 Architecture diagram
<p align="center">
  <!-- Replace with your own GIF or image -->
  <img src="img-1.jpg" alt="Java Selenium animation" width="900">
</p>

## 🧰 Architecture Implementation
<ul>
  <li>
    <p>Implement 2 different subnets (one public and the other private) in a custom VP</p>
  </li>
  <li>
    <p>Install and configure MySQL on an Amazon Linux 2 instance on the private subnet using the instructions provided. (Hint: Use a bastion host and a NAT gateway)</p>
  </li>
  <li>
    <p>Install and configure Mattermost on an Amazon Linux 2 instance on the public subnet using the provided instructions.</p>
  </li>
   <li>
    <p>Configure the security groups to allow the ports as shown in the architecture.</p>
  </li>
  <li>
    <p> Test the installation by accessing the IP of the public instance in a browser via the port 8065.</p>
  </li>
</ul>

---

## 🧰Step 1 (a): Creation of VPC
<ul>
  <li>
    <p>Navigate to VPC using the Services button at the top of the screen</p>
  </li>
  <li>
    <p>Select "Your VPCs" on the left side of the screen</p>
  </li>
  <li>
    <p>Click on "Create VPC".</p>
  </li>
   <li>
    <p>Enter the following fields:
            - Name: Project 1 VPC</li>
            - IPv4 CIDR Block: 10.0.0.0/16
            -  The rest of the options can be ignored.</p>
  </li>
  <li>
    <p> Select "Create VPC".</p>
  </li>
   <li>
    <p> Select the VPC and click on Actions->Edit DNS hostnames.</p>
  </li>
  <li>
    <p> Enable DNS hostnames and click on Save.</p>
  </li>

  <p align="center">
  <!-- Replace with your own GIF or image -->
     <img src="img-2.png" alt="Java Selenium animation" width="900">
     <img src="img-3.png" alt="Java Selenium animation" width="900">
     <img src="img-4.png" alt="Java Selenium animation" width="900">
</p>
</ul>



