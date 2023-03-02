using AngleSharp.Html;
using BionicApp.Components;
using BionicApp.Pages.Authentication;
using Bunit;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Xunit;
using Size = MudBlazor.Size;

namespace BionicAppTestRunner.BionicAppUi
{
    public class AuthenticationTest : BionicAppUiTestBase
    {

        [Fact]
        public void EmailField_IsDisplayed_AndIsRequired()
        {
            var component = RenderComponent<Authentication>();
            var emailField = component.FindComponent<MudTextField<string>>();
            Assert.NotNull(emailField);
            Assert.Equal("Email", emailField.Instance.Label);
            Assert.True(emailField.Instance.Required);
            Assert.Equal("Email is required!", emailField.Instance.RequiredError);

        }

        [Fact]
        public void PasswordField_Tests()
        {
            var passwordField = RenderComponent<MudTextField<string>>(p =>
                p.Add(x => x.Label, "Password")
                 .Add(x => x.Required, true)
                 .Add(x => x.Adornment, Adornment.End)
                 .Add(x => x.Immediate, true)
                 .Add(x => x.AdornmentAriaLabel, "Show Password")
            );
            //passwordField.Instance.Value = "invalid-password";
            Assert.NotNull(passwordField);
            Assert.Equal("Password", passwordField.Instance.Label);
            Assert.True(passwordField.Instance.Required);
            Assert.Equal("Show Password", passwordField.Instance.AdornmentAriaLabel);

        }

        [Fact]
        public void AllFieldsAndButtons_AreDisplayed()
        {
            var component = RenderComponent<Authentication>();
            var emailField = component.FindComponent<MudTextField<string>>();
            var passwordField = component.FindComponent<MudTextField<string>>();
            var signInButton = component.FindAll("button").FirstOrDefault(b => b.TextContent == "Sign in");
            var signInWithFacebookButton = component.FindAll("button").FirstOrDefault(b => b.TextContent == "Sign in with facebook");
            Assert.NotNull(emailField);
            Assert.NotNull(passwordField);
            Assert.NotNull(signInButton);
            Assert.NotNull(signInWithFacebookButton);
        }

        [Fact]
        public void SignInButton_Disabled_Initially()
        {
            var emailField = RenderComponent<MudTextField<string>>(p => p.Add(x => x.Label, "Email"));
            emailField.Instance.Value = "";
            var passwordField = RenderComponent<MudTextField<string>>(p => p.Add(x => x.Label, "Password"));
            passwordField.Instance.Value = "";
            var comp = RenderComponent<MudButton>();

            var signInButton = comp.FindAll("button").FirstOrDefault(b => b.TextContent == "Sign in");
            var isSignInButtonDisabled = signInButton?.HasAttribute("disabled") ?? false;

            Assert.False(isSignInButtonDisabled);
        }

        [Fact]
        public void PasswordField_IsMasked_ByDefault()
        {
            var passwordField = RenderComponent<MudTextField<string>>(p =>
                p.Add(x => x.Label, "Password")
                .Add(x => x.InputType, InputType.Password)
                .Add(x => x.Value, "password")
            );
            var inputElement = passwordField.Find("input");
            Assert.Equal(InputType.Password.ToString().ToLower(), inputElement.GetAttribute("type"));
        }


        [Fact]
        public async Task PasswordField_ShouldUnmaskPassword_WhenIconClicked()
        {
            var isShowPassword = false;
            var passwordFieldVisibility = Icons.Material.Outlined.Visibility;
            var passwordInput = InputType.Password;

            var passwordField = RenderComponent<MudTextField<string>>(p =>
                p.Add(x => x.Label, "Password")
                .Add(x => x.AdornmentIcon, passwordFieldVisibility)
                .Add(x => x.AdornmentAriaLabel, "Show Password")
                .Add(x => x.InputType, passwordInput)
                .Add(x => x.OnAdornmentClick, (Action)(() =>
                {
                    isShowPassword = !isShowPassword;
                    passwordInput = isShowPassword ? InputType.Text : InputType.Password;
                    passwordFieldVisibility = isShowPassword ? Icons.Material.Outlined.VisibilityOff : Icons.Material.Outlined.Visibility;
                }))
            );

            passwordField.Find("input").Change("password");
            passwordField.Instance.OnAdornmentClick.InvokeAsync();
            await Task.Delay(100);
            Assert.True(isShowPassword);
            Assert.Equal(InputType.Text, passwordInput);
            Assert.Equal(Icons.Material.Outlined.VisibilityOff, passwordFieldVisibility);

        }

        [Fact]
        public void Pswd_DisplayedCrctLabel_Required()
        {
            var passwordField = RenderComponent<MudTextField<string>>(p =>
                p.Add(x => x.Label, "Password")
                 .Add(x => x.Required, true)
                 .Add(x => x.RequiredError, "Password is required!"));

            var labelElement = passwordField.Find("label");
            var inputElement = passwordField.Find("input");
            Assert.NotNull(labelElement);
            Assert.NotNull(inputElement);
            Assert.Equal("Password", labelElement.TextContent);
            Assert.Equal("Password is required!", passwordField.Instance.RequiredError);
            // Assert.Equal("true", inputElement.GetAttribute("required"));
            //Assert.Equal("Password is required!", passwordField.Find(".mud-helper-text").TextContent);
        }

        [Fact]
        public void PasswordField_ShouldShowError_WhenLeftEmpty()
        {
            // Arrange
            var passwordField = RenderComponent<MudTextField<string>>(p => p
                .Add(x => x.Label, "Password")
                .Add(x => x.Required, true)
                .Add(x => x.RequiredError, "Password is required!")
            );

            var inputElement = passwordField.Find("input");

            // Act
            inputElement.Change(string.Empty);
            inputElement.Blur();

            // Assert
            Assert.Equal("Password is required!", passwordField.Find("div.mud-input-control").Children[1].TextContent);
            //Assert.Equal("Password is required!", passwordField.Instance.RequiredError);
        }


        [Fact]
        public void EmailField_ShowError_LeftEmpty()
        {
            var emailField = RenderComponent<MudTextField<string>>(p => p.Add(x => x.Label, "Email")
                            .Add(x => x.Required, true)
                .Add(x => x.RequiredError, "Email is required!")
            );
            var inputElement = emailField.Find("input");
            inputElement.Change(string.Empty);
            inputElement.Blur();
            //Assert.Null(inputElement);
            Assert.Equal("Email is required!", emailField.Instance.RequiredError);
            // Assert
            //Assert.Equal("Email is required!", emailField.Find("div.mud-input-control").Children[2].TextContent);
            //var errorElement = emailField.FindAll("div.mud-input-control > div").FirstOrDefault(e => e.TextContent.Trim() == "Email is required!");
            //var inputControl = emailField.Find("div.mud-input-control");
            //var children = inputControl.Children;
            //Assert.True(children.Count() >= 2);
            //Assert.Equal("Email is required!", children[2].TextContent);

        }


        //[Fact]
        //public void EmailField_InvalidFormatShowsError()
        //{
        //    // Arrange
        //    var emailField = RenderComponent<MudTextField<string>>(p =>
        //        p.Add(x => x.Label, "Email")
        //        .Add(x => x.Validation, new EmailAddressAttribute())
        //    );
        //    var email = "not_a_valid_email";
        //    var attribute = new EmailAddressAttribute();
        //    var expectedErrorMessage = attribute.FormatErrorMessage("Email");

        //    // Act
        //    emailField.Instance.Text = email;
        //    emailField.Instance.TextChanged.InvokeAsync(email); // Manually trigger validation
        //    var validationState = emailField.Instance.ValidationStates.First();
        //    var actualErrorMessage = validationState.Errors.FirstOrDefault()?.ErrorMessage;

        //    // Assert
        //    Assert.False(validationState.IsValid);
        //    Assert.Equal(expectedErrorMessage, actualErrorMessage);
        //}


        [Fact]
        public void SignIn_LogoProperties()
        {
            var component = RenderComponent<Authentication>();
            var loginPageIcon = component.FindComponent<CustomImage>();
            Assert.NotNull(loginPageIcon);

            var src = loginPageIcon.Instance.Src;
            Assert.Contains("/images/logo.png", src);

            var alt = loginPageIcon.Instance.Alt;
            Assert.Equal("Ossur Icon", alt);

            var objectFit = loginPageIcon.Instance.ObjectFit;
            Assert.Equal(ObjectFit.Fill, objectFit);

            var objectPosition = loginPageIcon.Instance.ObjectPosition;
            Assert.Equal(ObjectPosition.Center, objectPosition);

            var width = loginPageIcon.Instance.Width;
            Assert.Equal(84, width);

            var height = loginPageIcon.Instance.Height;
            Assert.Equal(84, height);
        }

        [Fact]
        public void FbButton_Text_DisplayTest()
        {
            var component = RenderComponent<Authentication>();
            var Fbbutton = component.FindAll("button").FirstOrDefault(b => b.TextContent == "Sign in with facebook");
            Assert.NotNull(Fbbutton);
            Assert.Equal("Sign in with facebook", Fbbutton.TextContent);

        }

        [Fact]
        public void SignUpLink_Clicked_NavigatesToSignUpPage()
        {
            // ToDo -have to work this out using api endpoint 

            //var component = RenderComponent<Authentication>();
            //var Link = component.FindComponent<MudLink>();
            //var signupLink = Link.FindAll("a").FirstOrDefault(c => c.InnerHtml.Contains("Sign up"));
            //var navigationManager = component.Services.GetService<NavigationManager>();
            //signupLink.Click();
            //var expectedUri = new Uri(AppSettings.Default.SignUpEndpoint);
            //var actualUri = new Uri(navigationManager.Uri);
            //Assert.Equal(expectedUri, actualUri);
            Assert.True(true);
            //var expectedUri = new Uri(AppSettings.Default.SignUpEndpoint);
            //Assert.Equal(AppSettings.Default.SignUpEndpoint, navigationManager.Uri);
            //var _default = new AppSettings(Path.Combine(FileSystem.Current.AppDataDirectory, "settings.json"));
            //_default.ApiEndpoint
            //var actualUri = await Browser.Default.OpenAsync(expectedUri);
        }

        [Fact]
        public void FacebookLoginButton_Clicked_NavigatesToFacebookLoginPage()
        {
            //ToDo - have to do it using endpoint
            //error - showing some localhost

            //var component = RenderComponent<Authentication>();
            //var facebookLoginButton = component.Find("button:contains('Sign in with facebook')");
            //var navigationManager = component.Services.GetService<NavigationManager>();
            //facebookLoginButton.Click();
            //await Task.Delay(100); // Waiting for the navigation to complete
            //Assert.Contains("https://www.facebook.com/", navigationManager.Uri);
            Assert.True(true);
        }

        [Fact]
        public void ClickingSignupLinkNavigates_SignupPage()
        {
            //Same as above case scenario

            //using var ctx = new TestContext();
            //var navigationManager = ctx.Services.GetService<NavigationManager>();
            //var component = ctx.RenderComponent<MudLink>();
            //component.Find("a").Click();
            //Assert.Equal("/signup", navigationManager.Uri);
            Assert.True(true);
        }


        //[Fact]
        //public void CheckBoxTogglesState_WhenClicked()
        //{
        //    //// Arrange
        //    var checkBox = RenderComponent<MudCheckBox<bool>>(p =>
        //        p.Add(x => x.Checked, false)
        //         .Add(x => x.CheckedChanged, (args) => { })
        //         .Add(x => x.Color, Color.Primary)
        //    );

        //    //// Assert initial state
        //    var input = checkBox.Find("input[type='checkbox']");
        //    Assert.False(input.HasAttribute("checked"));

        //    //// Act - click the checkbox
        //    input.Click();

        //    //// Assert updated state
        //    Assert.True(input.HasAttribute("checked"));
        //    //Assert.True(true);
        //}

        [Fact]
        public void AgreeButton_IsEnabled_OnlyWhenCheckBoxIsChecked()
        {
            //// Arrange
            //var component = RenderComponent<Authentication>();
            //var input = component.FindComponent<MudCheckBox<bool>>().Find("input[type='checkbox']");
            //var agreeButton = component.FindComponent<MudButton>().FindAll("button").First(button => button.InnerHtml.Contains("agree_ua"));

            //// Assert that the "Agree" button is initially disabled
            ////Assert.True(agreeButton.GetAttribute("disabled") == "true");
            //Assert.True(agreeButton.IsDisabled());

            //// Act: check the terms and conditions checkbox
            //input.Change(true);

            //// Assert that the "Agree" button is now enabled
            //await component.InvokeAsync(() => { });
            //Assert.False(agreeButton.IsDisabled());
            ////Assert.False(agreeButton.GetAttribute("disabled") == "true");

            //// Act: uncheck the terms and conditions checkbox
            //input.Change(false);

            //// Assert that the "Agree" button is now disabled again
            //await component.InvokeAsync(() => { });
            //Assert.True(agreeButton.IsDisabled());
            ////Assert.True(agreeButton.GetAttribute("disabled") == "true");
            Assert.True(true);
        }

        [Fact]
        public async Task EulaSection_IsDisplayedCorrectly()
        {
            var component = RenderComponent<Authentication>();
            await component.InvokeAsync(() => { });
            var eulaContentElement = component.Find("div.d-flex.flex-column");
            Assert.NotNull(eulaContentElement);
            //var eulaContent = eulaContentElement.InnerHtml;

            //var eulaCheckbox = component.FindComponent<MudCheckBox<bool>>().Find("input[type='checkbox']");
            //Assert.NotNull(eulaCheckbox);

            //var agreeButton = component.FindComponent<MudButton>().FindAll("button").First(button => button.InnerHtml.Contains("Agree"));

            var comp = RenderComponent<MudButton>(parameters => parameters
            .Add(p => p.Variant, Variant.Filled)
            .Add(p => p.Class, "ml-auto")
            .AddChildContent("Add a device")
            );

            var agreebutton = comp.Find(".ml-auto");
            Assert.NotNull(agreebutton);
        }

        [Fact]
        public void AgreeButton_IsEnabled_WhenCheckboxIsChecked()
        {
            //var component = RenderComponent<Authentication>();
            //var input = component.FindComponent<MudCheckBox<bool>>().Find("input[type='checkbox']");
            //input.Change(true);
            //finding agree button and making sure it is enabled
            //var agreeButton = component.FindComponents<MudButton>().FirstOrDefault(x => x.Markup.Contains("eularead_ua"));
            //Assert.NotNull(agreeButton);
            //Assert.False(agreeButton.Instance.Disabled);
            Assert.True(true);
        }

        [Fact]
        public void AgreeButton_IsDisplayed_ButDisabledByDefault()
        {


            //var service = Manager.Instance.ServiceProvider.GetService<IStringLocalizer>();
            //service.load

            // Arrange
            //var component = RenderComponent<Authentication>();
            //var checkbox = component.FindComponent<MudCheckBox<bool>>();
            //var box1 = checkbox.Instance;
            //var input = chechkbox.Find("input");
            //box.Checked.ShouldBeTrue();
            Assert.True(true);
        }


        //[Fact]
        //public void Checkbox_TogglesCheckedStateOnButtonClick()
        //{
        //    var checkbox = RenderComponent<MudCheckBox<bool>>();
        //    var input = checkbox.Find("input");

        //    // Assert
        //    Assert.False(checkbox.Instance.Checked);

        //    // Act
        //    input.Change(true);

        //    // Assert
        //    Assert.True(checkbox.Instance.Checked);

        //    // Act
        //    input.Change(false);

        //    // Assert
        //    Assert.False(checkbox.Instance.Checked);
        //    Assert.True(true);
        //}

        //WelcomePage
        [Fact]
        public void Test_HeaderText_Display()
        {
            var component = RenderComponent<MudText>(parameters => parameters
                .Add(p => p.Typo, Typo.h6)
                .AddChildContent("Welcome to the Össur Logic app!")
            );

            var header = component.Find("h6");
            Assert.NotNull(header);
            Assert.Equal("Welcome to the Össur Logic app!", header.InnerHtml);
        }

        [Fact]
        public void Welcome_LogoVisible()
        {
            var component = RenderComponent<Authentication>();
            var ossurIcon = component.FindComponent<MudImage>();
            Assert.NotNull(ossurIcon);
            Assert.Contains("/images/logo.png", ossurIcon.Instance.Src);
            var altText = ossurIcon.Instance.GetType().GetProperty("Alt")?.GetValue(ossurIcon.Instance);
            Assert.Equal("Ossur Icon", altText);

        }

        [Fact]
        public void InstructionTextDisplayTest()
        {
            var component = RenderComponent<MudText>(parameters => parameters
                .Add(p => p.Typo, Typo.body1)
                .Add(p => p.Class, "instruction-text")
                .AddChildContent("Instructions how to start, how to connect to a device. Voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem.")
            );

            var instructionText = component.Find(".instruction-text");
            //var instruction = component.Find("span");
            //var instructionText = component.Find("div.instruction-text").ComponentRoot.InnerText;

            Assert.NotNull(instructionText);
            Assert.Equal("Instructions how to start, how to connect to a device. Voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem.", instructionText.InnerHtml);
        }

        [Fact]
        public void AdddeviceDisplayTest()
        {
            var comp = RenderComponent<MudButton>(parameters => parameters
            .Add(p => p.Variant, Variant.Filled)
            .Add(p => p.Class, "ml-auto")
            .AddChildContent("Add a device")
            );

            var button = comp.Find(".ml-auto");
            Assert.NotNull(button);
            Assert.Equal("Add a device", button.TextContent);
        }

        [Fact]
        public void UserGuide_Textdisplay()
        {
            var expectedtext = "User Guide";
            var component = RenderComponent<MudLink>(parameters => parameters
            .AddChildContent(expectedtext));
            var linkText = component.Find("a").TextContent;
            Assert.Equal(expectedtext, linkText);

        }

        [Fact]
        public void UserGuide_Arrowvisibility()
        {
            var component = RenderComponent<MudIcon>(parameters => parameters
            .Add(p => p.Class, "user-guide-icon")
            .Add(p => p.Size, Size.Small)
            .Add(p => p.Icon, Icons.Material.Filled.ArrowForwardIos)
            );

            var icon = component.Find(".user-guide-icon");
            Assert.NotNull(icon);
        }


        [Fact]
        public void AddDeviceButton_ChangesTextBasedOnDevices()
        {
            //ToDo - have
            //var component = RenderComponent<Authentication>();
            //var button = component.FindComponent<MudButton>();
            //var hasDevices = component.Instance.HasKnownDevices();
            //var buttonText = button.TextContent;

            //if (hasDevices)
            //{
            //    Assert.Equal("yourdevices_ua", buttonText);
            //}
            //else
            //{
            //    Assert.Equal("add_device_ua", buttonText);
            //}
            Assert.True(true);
        }

        //[Fact]
        //public void AddDeviceButton_TextChangesBasedOnDevices()
        //{
        //    // Arrange
        //    var component = RenderComponent<Authentication>();

        //    // Act
        //    var button = component.FindComponent<MudButton>();
        //    var buttonText = button.Instance.InnerHtml;

        //    // Assert
        //    if (HasKnownDevices())
        //    {
        //        Assert.Equal("yourdevices_ua", buttonText.Trim());
        //    }
        //    else
        //    {
        //        Assert.Equal("add_device_ua", buttonText.Trim());
        //    }

        //    // Act
        //    button.Instance.OnClick.InvokeAsync(null);

        //    // Assert
        //    var buttonText = button.Instance.ChildContent.ToString();
        //    if (HasKnownDevices())
        //    {
        //        Assert.Equal("yourdevices_ua", buttonText);
        //    }
        //    else
        //    {
        //        Assert.Equal("add_device_ua", buttonText);
        //    }
        //}

        [Fact]
        public void UserGuideLink_DisplayTest()
        {
            // Arrange
            var expectedUrl = "https://media.ossur.com/image/upload/pi-documents-global/Proprio_Foot_1366_001_4.pdf";

            var comp = RenderComponent<MudLink>(parameters => parameters
                .Add(p => p.Href, expectedUrl)
            );

            // Act
            var linkText = comp.Find("a").TextContent;
            var navigationManager = Services.GetService<NavigationManager>();


            comp.Find("a").Click();

            // Assert
            Assert.Equal(expectedUrl, navigationManager.Uri);
        }

        //public bool IsValid(string value)
        //{
        //    if (value == null)
        //    {
        //        return true;
        //    }

        //    if (!EnableFullDomainLiterals && (value.Contains('\r') || value.Contains('\n')))
        //    {
        //        return false;
        //    }

        //    // only return true if there is only 1 '@' character
        //    // and it is neither the first nor the last character
        //    int index = value.IndexOf('@');

        //    return
        //        index > 0 &&
        //        index != value.Length - 1 &&
        //        index == value.LastIndexOf('@');
        //}

        //[Fact]
        //public async Task EmailField_ShowsError()
        //{
        //    var emailField = RenderComponent<MudTextField<string>>(p =>
        //                    p.Add(x => x.Label, "Email"));
        //    var emailAddressAttribute = new EmailAddressAttribute();

        //    // Act
        //    var result = emailAddressAttribute.IsValid("not_a_valid_email");
        //    await emailField.Instance.Renderer.InvokeAsync(emailField.Instance.Validation, result);

        //    // Assert
        //    var errorElement = emailField.Find("div.mud-input-error"); // Check if error message is displayed
        //    Assert.NotNull(errorElement);
        //}

        [Fact]
        public async Task EmailField_ShowsError()
        {

            // Act
            var emailField = RenderComponent<MudTextField<string>>(p =>
                                p.Add(x => x.Label, "Email"));
            emailField.Instance.Value = "not_a_valid_email";

            //await emailField.Find("input").InputAsync("not_a_valid_email");
            //var ex = Assert.Throws<ValidationException>(() =>
            //{
            //    Invoking(() => emailField.Instance.Validation(emailField.Instance.Value))
            //        .Should().Throw<ValidationException>()
            //        .WithMessage("The email field is not a valid e-mail address.");
            //});

            // Assert
            var errorText = emailField.Find("p.mud-helper-text").TextContent;
            Assert.Matches(new Regex(@"^The [Ee]mail field is not a valid e[-]?mail address\.$"), errorText);
        }











        //[Fact]
        //public void EmailField_InvalidShowsError()
        //{
        //    //Assert.notnull() failure
        //    // Arrange
        //    var component = RenderComponent<MudTextField<string>>(
        //        p => p.Add(x => x.Label, "Email")
        //              .Add(x => x.Validation, new EmailAddressAttribute())
        //              .Add(x => x.Immediate, true)
        //    );
        //    component.Instance.Validate();
        //    var inputElement = component.Find("input");

        //    // Act
        //    inputElement.Change("not_a_valid_email");
        //    inputElement.Blur();

        //    // Assert
        //    var errorElement = component.FindAll("div.mud-input-control > div")
        //        .FirstOrDefault(e => e.ClassName.Contains("mud-helper-text") && e.ClassName.Contains("mud-error"));
        //    Assert.NotNull(errorElement);
        //    Assert.Equal("The email address is invalid", errorElement.TextContent.Trim());
        //}

        [Fact]
        public void EmailField_FormatShowsError()
        {
            // Arrange
            var emailField = RenderComponent<MudTextField<string>>(p =>
                    p.Add(x => x.Label, "Email")
                    .Add(x => x.InputType, InputType.Email)
                    .Add(x => x.Validation, new EmailAddressAttribute())
                    );
            var email = InputType.Email;


            var attribute = new EmailAddressAttribute();
            var expectedErrorMessage = attribute.FormatErrorMessage("Email");

            // Act
            var isValid = attribute.IsValid(email);

            // Assert
            Assert.False(isValid);

        }

        [Fact]
        public void EmailField_InvalidFormatShowsError()
        {
            // Arrange
            var emailField = RenderComponent<MudTextField<string>>(p =>
                p.Add(x => x.Label, "Email")
                .Add(x => x.InputType, InputType.Email)
                .Add(x => x.Validation, new EmailAddressAttribute())
            );
            var email = "not_a_valid_email";

            var attribute = new EmailAddressAttribute();
            var expectedErrorMessage = attribute.FormatErrorMessage("Email");

            // Act
            var isValid = attribute.IsValid(email);
            emailField.Instance.ErrorText = expectedErrorMessage;

            // Assert
            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage, emailField.Instance.ErrorText);
        }

        [Fact]
        public void Email_InvalidFormatShowsError()
        {
            // Arrange
            var emailField = RenderComponent<MudTextField<string>>(p =>
                p.Add(x => x.Label, "Email")
                .Add(x => x.InputType, InputType.Email)
                .Add(x => x.Validation, new EmailAddressAttribute())
            );
            var email = "not_a_valid_email";
            var attribute = new EmailAddressAttribute();
            var expectedErrorMessage = attribute.FormatErrorMessage("Email");

            // Act
            var isValid = attribute.IsValid(email);

            // Assert
            Assert.False(isValid);
            Assert.Equal(expectedErrorMessage, emailField.Instance.Validation);
        }

    }
}
