## Scenario: Solving the Team communication and instant messaging problem

## Case study: Team communication and instant messaging solutions are an integral part of any business environment today. As of 2020, the total number of users of Slack and Microsoft Teams exceeded 20 million. Some organizations might have compliance policies in place which do not allow them to use services managed by third parties. They will prefer solutions that can be managed and hosted on servers controlled by them. The same will extend to communication solutions as well.

---

## 🧰 Architecture diagram
![img_5.png](img_5.png)

## 🧰 Architecture Implementation
- Implement 2 different subnets (one public and the other private) in a custom VP
- Install and configure MySQL on an Amazon Linux 2 instance on the private subnet using the instructions provided. (Hint: Use a bastion host and a NAT gateway)
- Install and configure Mattermost on an Amazon Linux 2 instance on the public subnet using the provided instructions.
- Configure the security groups to allow the ports as shown in the architecture.
- Test the installation by accessing the IP of the public instance in a browser via the port 8065.

---
