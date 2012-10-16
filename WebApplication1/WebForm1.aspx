<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="Nltd.Web.UI.WebControls.GoogleMap" Namespace="Nltd.Web.UI.WebControls.GoogleMap.StaticMapControl"
    TagPrefix="cc1" %>

<%@ Register Assembly="Artem.GoogleMap" Namespace="Artem.Web.UI.Controls" TagPrefix="cc2" %>
<%@ Register assembly="Nltd.Lib.GoogleMap" namespace="Nltd.Lib.GoogleMap.StaticMap.Modules" tagprefix="cc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <cc1:StaticMapBox ID="StaticMapBox1" Height="512" Width="512" Zoom="11" 
            runat="server" CenterAddress="Chicago">
            <CStyles>
                <cc3:MapStyle ElementType="geometry" FeatureType="road_highway" Hue="0xff0022" 
                    Lightness="-20" Saturation="60" />
                <cc3:MapStyle ElementType="geometry" FeatureType="road_arterial" Hue="0x2200ff" 
                    Lightness="-40" Saturation="30" Visibility="simplified" />
                <cc3:MapStyle FeatureType="road_local" Gamma="0.7" Hue="0xf6ff00" 
                    Saturation="60" Visibility="simplified" />
                <cc3:MapStyle ElementType="geometry" FeatureType="water" Lightness="40" 
                    Saturation="40" />
                <cc3:MapStyle ElementType="labels" FeatureType="road_highway" Saturation="98" 
                    Visibility="on" />
                <cc3:MapStyle ElementType="labels" FeatureType="administrative_locality" 
                    Gamma="0.9" Hue="0x0022ff" Lightness="-10" Saturation="50" />
                <cc3:MapStyle ElementType="geometry" FeatureType="transit_line" Hue="0xff0000" 
                    Lightness="-70" Visibility="on" />
            </CStyles>
        </cc1:StaticMapBox>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true">
            <asp:ListItem Text="Refresh"></asp:ListItem>
            <asp:ListItem Text="Again"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server" Text="1234"></asp:TextBox>
    </form>
    </body>
    
</html>
