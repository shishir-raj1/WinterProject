Feature: PlaceOrderFlow
  This feature covers the end-to-end flow of placing an order on the e-commerce website.

  @order
  Scenario Outline: End-to-end flow test
    Given user visits the e-commerce site, enters "<Username>" and "<Password>", and clicks on the login button
    When user selects the "<Product Name>" and clicks on the add to cart button
    And user goes to the cart page and clicks on the checkout button
    And user fills in the personal details on the checkout page and clicks on the continue button
      | key          | value          |
      | First Name   | <First Name>   |
      | Last Name    | <Last Name>    |
      | Postal Code  | <Postal Code>  |
    And user visits the checkout summary page and clicks on the Finish button
    Then user validates the success message "<Successful Message>"

  Examples:
    | S.no | Username      | Password     | Product Name          | First Name | Last Name | Postal Code | Successful Message        |
    | 1    | standard_user | secret_sauce | Sauce Labs Bike Light | Shishir    | Raj       | 823001      | Thank you for your order! |

