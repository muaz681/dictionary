<asp:GridView ID="assetGridviewID" runat="server" AutoGenerateColumns="False" Font-Size="12px" ShowFooter="True" CellPadding="3" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Left" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" CssClass="auto-style5" Width="100%" OnRowDataBound="assetGridviewID_RowDataBound">
                                        <Columns>

                                            <asp:TemplateField HeaderText="ID" SortExpression="srId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="intID" class="form-control cmmn_fnt_empList" Font-Size="8px" runat="server" Text='<%# Bind("intID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Width="80"/>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Count" SortExpression="srId">
                                                <ItemTemplate>
                                                    <asp:DropDownList class="form-select form-select-sm mb-3" ID="countID" runat="server">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Width="200" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Quality" SortExpression="srId">
                                                <ItemTemplate>
                                                    <asp:DropDownList class="form-select form-select-sm mb-3" ID="qualityID" runat="server">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity" SortExpression="srId">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="quantity" class="form-control cmmn_fnt_empList" runat="server" Text='<%# Bind("quantity") %>' OnTextChanged="calculatePrice" AutoPostBack="true"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Unit Price" SortExpression="srId">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="untPrice" class="form-control cmmn_fnt_empList" runat="server" Text='<%# Bind("untPrice") %>'  OnTextChanged="calculatePrice" AutoPostBack="true"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total Amount" SortExpression="srId">
                                                <ItemTemplate>
                                                    <asp:Label ID="totalPrice" class="form-control cmmn_fnt_empList" runat="server" Text='<%# Bind("totalPrice") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>


                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Details">
                                                <ItemTemplate>
                                                    <asp:Button class="btn btn-outline-success btn-sm" ID="btnUpdate" runat="server" OnClick="btnUpdateClick" Text="Update" CommandArgument='<%# Eval("intID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>

                                        </Columns>

                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                                    </asp:GridView>
