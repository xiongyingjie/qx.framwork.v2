//思想汇报：全部通过
render(function () {
    return [
        group([
            hide( 'thought_report-thought_report_id', '#id'),
            hide('thought_report-UserId', q.id),
            input('标题', 'thought_report-Describe', '', '4'),
            file('附件', 'thought_report-Attachment', 2, "/UserFile/join_party/thought_report_file/"),
            hideTime('thought_report-UploadTime', '#now'),
            hide( 'thought_report-StateID', '3'),
            hide( 'thought_report-is_read', '0')


        ], "思想汇报上传", 1)
    ];
}, 'ecampus.join_party.thought_report@add', '', "上传思想汇报");