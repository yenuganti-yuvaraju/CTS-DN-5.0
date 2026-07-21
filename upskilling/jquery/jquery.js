// ============================================================================
// jQuery Tutorial - Comprehensive Examples
// ============================================================================

$(document).ready(function () {
    console.log("Hello World!"); // 1. jQuery Library Inclusion - Console Log

    // ========================================================================
    // 1. jQuery Library Inclusion
    // ========================================================================
    // jQuery is loaded from CDN (in HTML file)
    // This file is the local jQuery.js that demonstrates its usage
    // Console shows "Hello World!" above

    $("#checkConsoleBtn").click(function () {
        alert("Check your browser console (F12) to see 'Hello World!' message!");
    });

    // ========================================================================
    // 2. The $() Function & $(document).ready()
    // ========================================================================
    // Change the heading text using jQuery
    $("#dynamicHeading").text("jQuery is ready! This text was changed using jQuery.");

    // Hide paragraph on button click
    $("#hideParaBtn").click(function () {
        $("#hideParagraph").hide();
    });

    // Show paragraph on button click
    $("#showParaBtn").click(function () {
        $("#hideParagraph").show();
    });

    // ========================================================================
    // 3. jQuery Methods - Hide, Show, Fade, Toggle, Slide & Chaining
    // ========================================================================

    // Hide effect
    $("#hideBtn").click(function () {
        $("#effectBox").hide();
    });

    // Show effect
    $("#showBtn").click(function () {
        $("#effectBox").show();
    });

    // Toggle effect (hide if visible, show if hidden)
    $("#toggleBtn").click(function () {
        $("#effectBox").toggle();
    });

    // Fade Out effect
    $("#fadeOutBtn").click(function () {
        $("#effectBox").fadeOut();
    });

    // Fade In effect
    $("#fadeInBtn").click(function () {
        $("#effectBox").fadeIn();
    });

    // Slide Up effect
    $("#slideUpBtn").click(function () {
        $("#effectBox").slideUp();
    });

    // Slide Down effect
    $("#slideDownBtn").click(function () {
        $("#effectBox").slideDown();
    });

    // Chained effects: slideUp() → delay() → slideDown()
    $("#chainBtn").click(function () {
        $("#effectBox")
            .slideUp()           // Slide up first
            .delay(500)          // Wait 500ms
            .slideDown();        // Then slide down
    });

    // ========================================================================
    // 4. DOM Manipulation - Form & Dynamic List
    // ========================================================================

    // Add item to list when button is clicked
    $("#addItemBtn").click(function () {
        var itemText = $("#itemInput").val(); // Get input value

        // Validate input is not empty
        if (itemText.trim() === "") {
            alert("Please enter an item!");
            return;
        }

        // Create a new list item and append it to the list
        var newItem = "<li>" + itemText + "</li>";
        $("#itemList").append(newItem);

        // Clear the input field
        $("#itemInput").val("");
    });

    // Remove all items from the list
    $("#removeAllBtn").click(function () {
        $("#itemList").empty(); // Remove all child elements
    });

    // Allow adding items by pressing Enter key in the input field
    $("#itemInput").keypress(function (event) {
        if (event.which === 13) { // 13 is the Enter key code
            $("#addItemBtn").click(); // Trigger the add button click
        }
    });

    // ========================================================================
    // 5. Working with Events - Click & Double-Click Color Change
    // ========================================================================

    var isRed = false; // Track current color state

    // Single click: change to red
    $("#colorBox").click(function () {
        if (!isRed) {
            $(this).css("background-color", "red");
            $(this).text("Red! Double-click to reset");
            isRed = true;
        }
    });

    // Double-click: change back to white
    $("#colorBox").dblclick(function () {
        $(this).css("background-color", "white");
        $(this).text("Click Me");
        isRed = false;
    });

    // ========================================================================
    // 6. Event Helpers - Mouse & Keyboard Events
    // ========================================================================

    // Mouse Enter event
    $("#eventBox").mouseenter(function () {
        $(this).css("background-color", "#e3f2fd");
        $("#eventLog").html("📍 Mouse entered!");
    });

    // Mouse Leave event
    $("#eventBox").mouseleave(function () {
        $(this).css("background-color", "white");
        $("#eventLog").html("📍 Mouse left!");
    });

    // Click event
    $("#eventBox").click(function () {
        $("#eventLog").html("👆 Box clicked!");
    });

    // Double-click event
    $("#eventBox").dblclick(function () {
        $("#eventLog").html("👆 Box double-clicked!");
    });

    // Keypress event on input field
    $("#keyInput").keypress(function (event) {
        var key = String.fromCharCode(event.which); // Get the character pressed
        $("#eventLog").html("⌨️ Key pressed: '" + key + "' (code: " + event.which + ")");
    });

    // Keyup event for additional feedback
    $("#keyInput").keyup(function () {
        var currentValue = $(this).val();
        if (currentValue.length > 0) {
            $("#eventLog").append(" | Current text: '" + currentValue + "'");
        }
    });

    // ========================================================================
    // Additional jQuery Demonstrations
    // ========================================================================

    // You can also use jQuery for:
    // - $(selector).addClass() / .removeClass() / .toggleClass()
    // - $(selector).attr() / .removeAttr()
    // - $(selector).html() / .text()
    // - $(selector).css() for inline styling
    // - $(selector).filter() / .find() / .children() / .parent()
    // - $.ajax() / $.get() / $.post() for AJAX requests
    // - jQuery animations with .animate()
    // - jQuery effects with .delay(), .queue(), .clearQueue()

    console.log("jQuery Tutorial loaded successfully!");
    console.log("All event handlers and effects are ready to use.");
});